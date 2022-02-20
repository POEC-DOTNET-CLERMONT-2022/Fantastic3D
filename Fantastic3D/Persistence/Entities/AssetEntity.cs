using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fantastic3D.DataManager;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Defines an asset, his price and his associated tags.
    /// </summary>
    [Table("Asset")]
    public class AssetEntity : IManageable
    {
        public enum PublicationStatus { Unpublished, Published, Rejected, Removed }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; }
        public float Price { get; set; }
        public string FilePath { get; set; }
        public string PicturePath { get; set; }
        public List<TagEntity> Tags { get; set; }
        public int CreatorId { get; set; }
        public PublicationStatus Status { get; set; }
        public virtual UserEntity Creator { get; set; }
        public virtual ICollection<ReviewEntity> Reviews { get; private set; }

        public AssetEntity()
        {
            this.Reviews = new HashSet<ReviewEntity>();
        }
        public AssetEntity(string name, string description, float price, string filePath, string picturePath, List<TagEntity> tags, int creatorId, PublicationStatus status)
        {
            Name = name;
            Description = description;
            Price = price;
            FilePath = filePath;
            PicturePath = picturePath;
            Tags = tags;
            CreatorId = creatorId;
            Status = status;
        }

        /// <summary>
        /// Constructor for an Asset, setting it with a NewGuid and with an Unpublished status.
        /// </summary>
        public AssetEntity(string name, string description, float price, string filePath, string picturePath, int creator)
            : this(name, description, price, filePath, picturePath, new List<TagEntity>(), creator, PublicationStatus.Unpublished) { }

        public override string ToString()
        {
            return $"Model: {Name}, price : {Price}, file path : {FilePath}";
        }

    }
}
