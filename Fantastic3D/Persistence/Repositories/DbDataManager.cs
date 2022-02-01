using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantastic3D.DataManager;

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
        LocalDbContext _context;
        private IMapper _mapper;
        private DbSet<TEntity> _dataSet;

        public DbDataManager(LocalDbContext context, IMapper mapper)
        {
            _context = context;
            _dataSet = context.Set<TEntity>();
            _mapper = mapper;
        }

        public async Task<TTransfered> GetAsync(int id)
        {
            var result = await _dataSet.SingleAsync(user => user.Id == id);
            return _mapper.Map<TTransfered>(result);
        }

        public async Task<IEnumerable<TTransfered>> GetAllAsync()
        {
            return await Task.FromResult(_dataSet.Select(user => _mapper.Map<TTransfered>(user)));
        }

        public async Task AddAsync(TTransfered objectToAdd)
        {
            if (objectToAdd == null)
                throw new ArgumentNullException("Can't add an empty value.");
            // TODO : [DbRepository/ADD] gérer le dédoublonnage lors de l'ajout, ici ou dans le modèle d'entités
            _dataSet.Add(_mapper.Map<TEntity>(objectToAdd));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, TTransfered transferedObject)
        {
            _dataSet.Update(_mapper.Map<TEntity>(transferedObject));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Todo : [DbRepository/DEL] remplacer Find par une creation d'objet ayant juste l'ID recherché
            var dataToDelete = _dataSet.Find(id);
            if (dataToDelete == null)
                throw new NullReferenceException("Element to delete wasn't found");
            _dataSet.Remove(dataToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
