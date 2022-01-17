using System.Runtime.Serialization;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Defines a Tag. A tags holds a name and belongs to a tagType
    /// </summary>
    [DataContract]
    public class TagEntity : IPersistable
    {
        [DataMember]
        private string _name;
        [DataMember]
        private TagTypeEntity _tagType;

        public TagEntity(string name, TagTypeEntity tagType)
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
