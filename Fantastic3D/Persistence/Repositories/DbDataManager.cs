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
        readonly LocalDbContext _context;
        readonly private IMapper _mapper;
        readonly private DbSet<TEntity> _dataSet;

        public DbDataManager(LocalDbContext context, IMapper mapper)
        {
            _context = context;
            _dataSet = context.Set<TEntity>();
            _mapper = mapper;
        }

        public async Task<TTransfered> GetAsync(int id)
        {
            var result = await _dataSet.SingleAsync(item => item.Id == id);
            return _mapper.Map<TTransfered>(result);
        }

        public async Task<IEnumerable<TTransfered>> GetAllAsync()
        {
            var dataList = await _dataSet.ToListAsync();
            return dataList.Select(item => _mapper.Map<TTransfered>(item));
        }

        public async Task AddAsync(TTransfered objectToAdd)
        {
            if (objectToAdd == null)

                throw new DataRecordException("Can't add an empty value.");
            // TODO : [DbRepository/ADD] gérer le dédoublonnage lors de l'ajout, ici ou dans le modèle d'entités
            _dataSet.Add(_mapper.Map<TEntity>(objectToAdd));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, TTransfered objectToUpdate)
        {
            var mappedObjectToUpdate = _mapper.Map<TEntity>(objectToUpdate);

            if (mappedObjectToUpdate == null)
                throw new DataRecordException("Could not convert object.");
            if (mappedObjectToUpdate.Id == 0)
                mappedObjectToUpdate.Id = id;
            if (mappedObjectToUpdate.Id != id)
                throw new IdMismatchException("Id sent is the method did not match Id of the object and can potentially cause an update of the wrong object.");
            if(mappedObjectToUpdate is AssetEntity assetToUpdate)
            {
                var assetInDb = await _context.Set<AssetEntity>().SingleAsync(item => item.Id == assetToUpdate.Id);
                if (assetToUpdate.CreatorId == 0)
                    assetToUpdate.CreatorId = assetInDb.CreatorId;
                if (!assetToUpdate.Tags.Any() && assetInDb.Tags.Any())
                    assetToUpdate.Tags = assetInDb.Tags;
                _context.Set<AssetEntity>().Update(assetToUpdate);
            }
            else
            { 
                _dataSet.Update(mappedObjectToUpdate);
            }
            var affectedRows = await _context.SaveChangesAsync();
            if(affectedRows != 1)
            {
                throw new DataRecordException("More than one row was affected by this update.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            // Todo : [DbRepository/DEL] remplacer Find par une creation d'objet ayant juste l'ID recherché
            var dataToDelete = _dataSet.Find(id);
            if (dataToDelete == null)
                throw new DataRecordException("Element to delete wasn't found");
            _dataSet.Remove(dataToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
