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
        public string Name { get; set; }
        public TagType TagType { get; set; }
        public bool Active { get; set; }

        public Tag(string name, TagType tagType)
        {
            Name = name;
            TagType = tagType;
        }

        public override string ToString()
        {
            return $"{Name} (de type {TagType.Name})";
        }
        public void Rename(string newName)
        {
            Name = newName;
        }
    }
}
