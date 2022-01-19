using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Defines a Tag. A tags holds a name and belongs to a tagType
    /// </summary>
    [Table("Tag")]
    public class TagEntity : IPersistable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int TagTypeId { get; set; }
        public virtual TagTypeEntity TagType { get; private set; }
        public virtual ICollection<AssetEntity> Assets { get; private set; }

        public TagEntity() { }

        public TagEntity(string name, int tagTypeId)
        {
            Name = name;
            TagTypeId = tagTypeId;
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
