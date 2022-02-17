using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantastic3D.DataManager;
using Fantastic3D.Persistence.Entities;

namespace Fantastic3D.Persistence
{
    /// <summary>
    /// Class performing the CRUD operation with conversion. Requires a DbContext and a mapper.
    /// </summary>
    /// <typeparam name="TTransfered">A Dto type, used in the method's arguments and return types.</typeparam>
    /// <typeparam name="TEntity">An Entity type, that will be written in the DataBase.</typeparam>
    public class DbDataManager<TTransfered, TEntity> : IDataManager<TTransfered, TEntity>
        where TTransfered : class, IManageable, new()
        where TEntity : class, IManageable, new()
    {
        private readonly IDbContextFactory<LocalDbContext> _contextFactory;
        readonly private IMapper _mapper;

        public DbDataManager(IDbContextFactory<LocalDbContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<TTransfered> GetAsync(int id)
        {
            using LocalDbContext context = _contextFactory.CreateDbContext();
            var result = await context.Set<TEntity>().SingleAsync(item => item.Id == id);
            return _mapper.Map<TTransfered>(result);
        }

        public async Task<IEnumerable<TTransfered>> GetAllAsync()
        {
            using LocalDbContext context = _contextFactory.CreateDbContext();
            var dataList = await context.Set<TEntity>().ToListAsync();
            return dataList.Select(item => _mapper.Map<TTransfered>(item));
        }

        public async Task AddAsync(TTransfered objectToAdd)
        {
            using LocalDbContext context = _contextFactory.CreateDbContext();
            if (objectToAdd == null)
                throw new DataRecordException("Can't add an empty value.");
            // TODO : [DbRepository/ADD] gérer le dédoublonnage lors de l'ajout, ici ou dans le modèle d'entités
            context.Set<TEntity>().Add(_mapper.Map<TEntity>(objectToAdd));
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, TTransfered objectToUpdate)
        {
            using LocalDbContext context = _contextFactory.CreateDbContext();
            var mappedObjectToUpdate = _mapper.Map<TEntity>(objectToUpdate);

            if (mappedObjectToUpdate == null)
                throw new DataRecordException("Could not convert object.");
            if (mappedObjectToUpdate.Id != id)
                throw new IdMismatchException("The ID in the endpoint doesn't match the ID of the object in the body and can potentially cause an update of the wrong object.");
            if(mappedObjectToUpdate is AssetEntity assetToUpdate)
            {
                var assetInDb = await context.Set<AssetEntity>().SingleAsync(item => item.Id == assetToUpdate.Id);
                if (assetToUpdate.CreatorId == 0)
                    assetToUpdate.CreatorId = assetInDb.CreatorId;
                if (!assetToUpdate.Tags.Any() && assetInDb.Tags.Any())
                    assetToUpdate.Tags = assetInDb.Tags;
                context.Set<AssetEntity>().Update(assetToUpdate);
            }
            else
            {
                context.Set<TEntity>().Update(mappedObjectToUpdate);
            }
            var affectedRows = await context.SaveChangesAsync();
            if(affectedRows != 1)
            {
                throw new DataRecordException("More than one row was affected by this update.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            using LocalDbContext context = _contextFactory.CreateDbContext();
            // Todo : [DbRepository/DEL] remplacer Find par une creation d'objet ayant juste l'ID recherché
            var dataToDelete = context.Set<TEntity>().Find(id);
            if (dataToDelete == null)
                throw new DataRecordException("Element to delete wasn't found");
            context.Set<TEntity>().Remove(dataToDelete);
            await context.SaveChangesAsync();
        }
    }
}
