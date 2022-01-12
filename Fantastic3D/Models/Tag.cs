using System.Runtime.Serialization;

namespace Fantastic3D.Models
{
    /// <summary>
    /// Defines a Tag. A tags holds a name and belongs to a tagType
    /// </summary>
    [DataContract]
    public class Tag : IPersistable
    {
        [DataMember]
        private string _name;
        [DataMember]
        private TagType _tagType;

        public Tag(string name, TagType tagType)
        {
            _name = name;
            _tagType = tagType;
        }

        public override string ToString()
        {
            return $"{_name} (of type {_tagType.Name})";
        }
        public void Rename(string newName)
        {
            _name = newName;
        }
    }
}
