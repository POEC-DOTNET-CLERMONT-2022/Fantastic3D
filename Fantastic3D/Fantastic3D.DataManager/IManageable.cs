namespace Fantastic3D.DataManager
{
    /// <summary>
    /// Describes a class that contains an Id, making it compliant with IDataManager.
    /// </summary>
    public interface IManageable
    {
        public int Id { get; set; }
        /// <summary>
        /// Allows a soft deletion in the DataBase by putting the "Active" bool to false.
        /// </summary>
        public bool Active { get; set; }
    }
}
