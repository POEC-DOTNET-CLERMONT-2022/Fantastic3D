namespace Fantastic3D.Persistence
{
    /// <summary>
    /// Interface for generic repository classes for IPersistable edition
    /// </summary>
    public interface IRepository<T>
        where T : Entities.IPersistable
    {
        public IEnumerable<T> GetAll();
        public T Get(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}