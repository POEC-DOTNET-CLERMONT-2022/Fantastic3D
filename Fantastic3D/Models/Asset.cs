using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.Models
{
    /// <summary>
    /// Defines an asset, his price and his associated tags.
    /// </summary>
    public class Asset
    {
        private Guid _uniqueId;
        private string _name;
        private string _description;
        private float _price;
        private string _filePath;
        private List<Tag> _tags;

        public Asset(Guid uniqueId, string name, string description, float price, string filePath, List<Tag> tags)
        {
            _uniqueId = Guid.NewGuid();
            _name = name;
            _description = description;
            _price = price;
            _filePath = filePath;
            _tags = tags;
        }

        public override string ToString()
        {
            return $"Model: {_name} (price : {_price}, file path : {_filePath}";
        }

    }
}
