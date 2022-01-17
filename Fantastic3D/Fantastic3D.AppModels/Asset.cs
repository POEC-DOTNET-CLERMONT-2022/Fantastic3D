using System.Runtime.Serialization;

namespace Fantastic3D.AppModels
{
    /// <summary>
    /// Defines an asset, his price and his associated tags.
    /// </summary>
    [DataContract]
    public class Asset : ObservableModel
    {
        public enum Status { Unpublished, Published, Rejected, Removed }

        private Guid _id;
        private string _name;
        private string _description;
        private float _price;
        private string _filePath;
        private string _picturePath;
        private List<Tag> _tags;    // TODO : vérifier si ça ne duplique pas les instances de tag, si oui il faut faire le lien Asset <--> Tag autrement.
        private User _creator;
        private Status _status;

        public Asset(Guid id, string name, string description, float price, string filePath, string picturePath, List<Tag> tags, User creator, Status status)
        {
            _id = id;
            _name = name;
            _description = description;
            _price = price;
            _filePath = filePath;
            _picturePath = picturePath;
            _tags = tags;
            _creator = creator;
            _status = status;
        }

        /// <summary>
        /// Constructor for an Asset, setting it with a NewGuid and with an Unpublished status.
        /// </summary>
        public Asset(string name, string description, float price, string filePath, string picturePath, List<Tag> tags, User creator)
            : this(Guid.NewGuid(), name, description, price, filePath, picturePath, tags, creator, Status.Unpublished) { }

        public override string ToString()
        {
            return $"Model: {_name}, price : {_price}, file path : {_filePath}";
        }

    }
}
