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
        /// <summary>
        /// Gets a IEnumerable of all objects from the repository.
        /// </summary>
        /// <exception cref="DataRetrieveException">Thrown when an error occurs while retrieving data.</exception>
        public Task<IEnumerable<TTransfered>> GetAllAsync();
        /// <summary>
        /// Gets a specific object from the repository, by its ID.
        /// </summary>
        /// <exception cref="DataRetrieveException">Thrown when an error occurs while retrieving data.</exception>
        public Task<TTransfered> GetAsync(int id);
        /// <summary>
        /// Adds a new object to a data repository.
        /// </summary>
        /// <exception cref="DataRecordException">Thrown when an error occurs while recording data.</exception>
        public Task AddAsync(TTransfered objectToAdd);
        /// <summary>
        /// Updates an object in the data repository.
        /// </summary>
        /// <exception cref="DataRecordException">Thrown when an error occurs while recording data.</exception>
        /// <exception cref="IdMismatchException">Thrown when the object's Id doesn't match the Id specified in <param>id</param></param>.</exception>
        public Task UpdateAsync(int id, TTransfered objectToUpdate);
        /// <summary>
        /// Deletes an object from the data repository.
        /// </summary>
        /// <exception cref="DataRecordException">Thrown when an error occurs while recording data.</exception>
        public Task DeleteAsync(int id);
    }
}