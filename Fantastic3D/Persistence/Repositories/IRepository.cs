namespace Fantastic3D.Persistence
{
    /// <summary>
    /// Interface allowing Data Transfert Objects to be set in persistable contexts, such as XML files or databases.
    /// </summary>
    /// <typeparam name="TTransfered">Typically, a Dto class.</typeparam>
    /// <typeparam name="TPersistant">A class than can be saved into persistance.</typeparam>
    public interface IRepository<TTransfered, TPersistant>
        where TTransfered : class, new()
        where TPersistant : class, new()
    {
        public IEnumerable<TTransfered> GetAll();
        public TTransfered Get(int id);
        public void Add(TTransfered transferedObject);
        public void Update(int id, TTransfered transferedObject);
        public void Delete(int id);
    }
}