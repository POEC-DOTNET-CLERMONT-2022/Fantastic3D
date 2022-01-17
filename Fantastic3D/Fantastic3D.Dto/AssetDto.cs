using System.Runtime.Serialization;

namespace Fantastic3D.Dto
{
    /// <summary>
    /// Data Transfert Object for an asset
    /// </summary>
    [DataContract]
    public class AssetDto
    {
        public enum Status { Unpublished, Published, Rejected, Removed }

        private Guid _id;
        private string _name;
        private string _description;
        private float _price;
        private string _filePath;
        private string _picturePath;
        private List<Guid> _tags;    // List of Tags Ids
        private int _creator;       // User ID
        private string _status;

    }
}
