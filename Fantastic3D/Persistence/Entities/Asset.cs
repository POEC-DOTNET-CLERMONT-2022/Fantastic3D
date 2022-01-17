using System.Runtime.Serialization;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Defines an asset, his price and his associated tags.
    /// </summary>
    [DataContract]
    public class Asset : IPersistable
    {
        public enum Status { Unpublished, Published, Rejected, Removed }

        [DataMember]
        private Guid _id;
        [DataMember]
        private string _name;
        [DataMember]
        private string _description;
        [DataMember]
        private float _price;
        [DataMember]
        private string _filePath;
        [DataMember]
        private string _picturePath;
        [DataMember]
        private List<Tag> _tags;    // TODO : vérifier si ça ne duplique pas les instances de tag, si oui il faut faire le lien Asset <--> Tag autrement.
        [DataMember]
        private User _creator;
        [DataMember]
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
