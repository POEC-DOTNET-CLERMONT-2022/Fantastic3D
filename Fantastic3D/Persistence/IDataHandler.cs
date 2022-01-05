using Fantastic3D.Models;

namespace Fantastic3D.Persistence
{
    /// <summary>
    /// Les éléments de cette interface peuvent
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