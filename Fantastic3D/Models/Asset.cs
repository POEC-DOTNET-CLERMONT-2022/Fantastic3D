

namespace Fantastic3D.Models
{
    /// <summary>
    /// Defines an asset, his price and his associated tags.
    /// </summary>
    public class Asset
    {
        private Guid _id;
        private string _name;
        private string _description;
        private float _price;
        private string _filePath;
        private List<Tag> _tags;
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
