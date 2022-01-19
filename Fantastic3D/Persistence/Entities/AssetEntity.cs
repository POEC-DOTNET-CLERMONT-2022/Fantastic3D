
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Defines an asset, his price and his associated tags.
    /// </summary>
    [Table("Asset")]
    public class AssetEntity : IPersistable
    {
        public enum PublicationStatus { Unpublished, Published, Rejected, Removed }
        [Key, Column("Id")]
        public int Id { get; set; }
        private static int _currentId = 1;
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; }
        public float Prince { get; set; }
        public string FilePath { get; set; }
        public string PicturePath { get; set; }
        // allows the relationnal table to be created between
        public virtual ICollection<TagEntity> Tags { get; private set; }
        public int CreatorId { get; set; }


        public PublicationStatus Status { get; set; }

        public virtual UserEntity Creator { get; private set; }
        public virtual ICollection<ReviewEntity> Reviews { get; private set; }

        public AssetEntity()
        {
            this.Reviews = new HashSet<ReviewEntity>();
        }
        public AssetEntity(int id, string name, string description, float price, string filePath, string picturePath, List<TagEntity> tags, UserEntity creator, PublicationStatus status)
        {
            Id = id;
            Name = name;
            Description = description;
            Prince = price;
            FilePath = filePath;
            PicturePath = picturePath;
            Tags = tags;
            Creator = creator;
            Status = status;
        }

        /// <summary>
        /// Constructor for an Asset, setting it with a NewGuid and with an Unpublished status.
        /// </summary>
        public AssetEntity(string name, string description, float price, string filePath, string picturePath, List<TagEntity> tags, UserEntity creator)
            : this(_currentId++, name, description, price, filePath, picturePath, tags, creator, PublicationStatus.Unpublished) { }

        public override string ToString()
        {
            return $"Model: {Name}, price : {Prince}, file path : {FilePath}";
        }

    }
}
