using Fantastic3D.Models;

namespace Fantastic3D.Persistence
{
    /// <summary>
    /// Elements of this interface can Load and Save Data of various formats
    /// </summary>
    public interface IDataHandler
    {
        /// <summary>
        /// Tries to save the data using identifier dataIdentifier.
        /// </summary>
        public void SaveData(string dataIdentifier, object obj);

        /// <summary>
        /// Tries to get the data using the identifier dataIdentifier.
        /// Returns an empty value if no file exists.
        /// </summary>
        public object LoadData(string dataIdentifier);
    }
}