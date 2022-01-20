namespace Fantastic3D.DataManager
{
    /// <summary>
    /// Interface allowing Data Transfert Objects to be set in persistable contexts, such as XML files or databases.
    /// </summary>
    /// <typeparam name="TTransfered">Typically, a Dto class.</typeparam>
    /// <typeparam name="TPersistant">A class than can be saved into persistance.</typeparam>
    public interface IDataManager<TTransfered, TPersistant>
        where TTransfered : IManageable, new()
        where TPersistant : IManageable, new()
    {
        public IEnumerable<TTransfered> GetAll();
        public TTransfered Get(int id);
        public void Add(TTransfered transferedObject);
        public void Update(int id, TTransfered transferedObject);
        public void Delete(int id);
    }
}