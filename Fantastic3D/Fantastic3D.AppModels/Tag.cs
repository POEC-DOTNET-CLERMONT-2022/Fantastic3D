using System.Runtime.Serialization;
using Fantastic3D.DataManager;
namespace Fantastic3D.AppModels
{
    /// <summary>
    /// Defines a Tag. A tags holds a name and belongs to a tagType
    /// </summary>
    
    public class Tag : ObservableModel, IManageable
    {
        public int Id { get; set; }

        private string _name;

        private TagType _tagType;

        public Tag(string name, TagType tagType)
        {
            _name = name;
            _tagType = tagType;
        }

        public override string ToString()
        {
            return $"{_name} (de type {_tagType.Name})";
        }
        public void Rename(string newName)
        {
            _name = newName;
        }
    }
}
