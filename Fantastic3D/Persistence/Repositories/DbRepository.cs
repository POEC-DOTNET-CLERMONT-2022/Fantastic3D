using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.Persistence
{
    /// <summary>
    /// Class performing the CRUD operation with conversion. Requires a DbContext and a mapper.
    /// </summary>
    /// <typeparam name="TTransfered">A Dto type, used in the method's arguments and return types.</typeparam>
    /// <typeparam name="TEntity">An Entity type, that will be written in the DataBase.</typeparam>
    public class DbRepository<TTransfered, TEntity> : IRepository<TTransfered, TEntity>
        where TTransfered : class, new()
        where TEntity : class, Entities.IPersistable, new()
    {
        LocalDbContext _context;
        private IMapper _mapper;
        private DbSet<TEntity> _dataSet;

        public DbRepository(LocalDbContext context, IMapper mapper)
        {
            _context = context;
            _dataSet = context.Set<TEntity>();
            _mapper = mapper;
        }

        public TTransfered Get(int id)
        {
            return _mapper.Map<TTransfered>(_dataSet.Single(user => user.Id == id));
        }

        public IEnumerable<TTransfered> GetAll()
        {
            return _dataSet.Select(user => _mapper.Map<TTransfered>(user));
        }

        public void Add(TTransfered objectToAdd)
        {
            if (objectToAdd == null)
                throw new ArgumentNullException("Can't add an empty value.");
            // TODO : [DbRepository/ADD] gérer le dédoublonnage lors de l'ajout, ici ou dans le modèle d'entités
            _dataSet.Add(_mapper.Map<TEntity>(objectToAdd));
            _context.SaveChanges();
        }

        public void Update(int id, TTransfered transferedObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var dataToDelete = _dataSet.Find(id);
            if (dataToDelete == null)
                throw new NullReferenceException("Element to delete wasn't found");
            _dataSet.Remove(dataToDelete);
            _context.SaveChanges();
        }
    }
}
