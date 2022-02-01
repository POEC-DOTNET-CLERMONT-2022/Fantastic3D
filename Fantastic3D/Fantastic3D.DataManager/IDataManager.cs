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
        public Task<IEnumerable<TTransfered>> GetAllAsync();
        public Task<TTransfered> GetAsync(int id);
        public Task AddAsync(TTransfered transferedObject);
        public Task UpdateAsync(int id, TTransfered transferedObject);
        public Task DeleteAsync(int id);
    }
}