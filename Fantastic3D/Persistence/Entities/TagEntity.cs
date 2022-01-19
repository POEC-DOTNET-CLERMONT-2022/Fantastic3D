using System.ComponentModel.DataAnnotations;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Defines a Tag. A tags holds a name and belongs to a tagType
    /// </summary>
    public class TagEntity : IPersistable
    {
        [Key]
        public int Id;
        public string Name;
        public TagTypeEntity TagType;

        public TagEntity(string name, TagTypeEntity tagType)
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
