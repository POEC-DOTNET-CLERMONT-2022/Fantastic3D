namespace Fantastic3D.Entities
{
    /// <summary>
    /// Interface for generic repository classes for IPersistable edition
    /// </summary>
    public interface IRepository<T>
        where T : IPersistable
    {
        public IEnumerable<T> GetAll();
        public T Get(long id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}