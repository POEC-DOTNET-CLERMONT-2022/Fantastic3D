using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Fantastic3D.DataManager;

namespace Fantastic3D.Persistence.Entities
{

    /// <summary>
    /// A type of tag, with tag constraints
    /// </summary>
    [Table("TagType")]
    public class TagTypeEntity : IManageable
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; private set; }
        /// <summary>
        /// Defines if at tag is mandatory (needs to be added at least 1 time to an asset)
        /// </summary>
        public bool IsMandatory { get; private set; }
        /// <summary>
        /// Defines if a tag must only be used once or can be used multiple times.
        /// </summary>
        public bool IsOnlyOne { get; private set; }

        public TagTypeEntity(string name, bool isMandatory, bool isOnlyOne)
        {

            Name = name;
            IsMandatory = isMandatory;
            IsOnlyOne = isOnlyOne;
        }
        public TagTypeEntity() {}

        public override string ToString()
        {
            return $"{Name} (" + (IsMandatory ? "obligatoire " : "") + (IsOnlyOne ? "unique" : "plusieurs") + ").";
        }
    }
}