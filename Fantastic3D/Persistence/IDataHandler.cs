

namespace Fantastic3D.Persistence
{
    /// <summary>
    /// Elements of this interface can Load and Save Data implementing IPeristable
    /// </summary>
    public interface IDataHandler<T>
        where T : Entities.IPersistable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listToSave">Data which will be saved.</param>
        public void SaveData(List<T> listToSave);

        /// <summary>
        /// Loads data for the corresponding class into loadedList.
        /// If data exists for a given instance, it will be overwritten.
        /// </summary>
        /// <param name="loadedList">List in which the data will be populated.</param>
        public void LoadData(List<T> loadedList);
    }
}