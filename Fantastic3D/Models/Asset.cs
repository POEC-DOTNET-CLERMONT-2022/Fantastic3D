using System.Runtime.Serialization;

namespace Fantastic3D.Models
{
    /// <summary>
    /// Defines an asset, his price and his associated tags.
    /// </summary>
    [DataContract]
    public class Asset : IPersistable
    {
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
        private List<Tag> _tags;    // TODO : vérifier si ça ne duplique pas les instances de tag, si oui il faut faire le lien Asset <--> Tag autrement.
        [DataMember]
        private User _creator;

        public Asset(Guid id, string name, string description, float price, string filePath, List<Tag> tags, User creator)
        {
            _id = id;
            _name = name;
            _description = description;
            _price = price;
            _filePath = filePath;
            _tags = tags;
            _creator = creator;
        }

        public override string ToString()
        {
            return $"Model: {_name}, price : {_price}, file path : {_filePath}";
        }

    }
}
