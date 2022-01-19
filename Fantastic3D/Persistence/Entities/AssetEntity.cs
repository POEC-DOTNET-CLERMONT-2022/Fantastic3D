
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Defines an asset, his price and his associated tags.
    /// </summary>
    public class AssetEntity : IPersistable
    {
        public enum PublicationStatus { Unpublished, Published, Rejected, Removed }
        [Key, Column("Id")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Prince { get; set; }
        public string FilePath { get; set; }
        public string PicturePath { get; set; }
        public List<TagEntity> Tags { get; set; }    // TODO : vérifier si ça ne duplique pas les instances de tag, si oui il faut faire le lien Asset <--> Tag autrement.
        public UserEntity Creator { get; set; }
        public PublicationStatus Status { get; set; }

        public AssetEntity(Guid id, string name, string description, float price, string filePath, string picturePath, List<TagEntity> tags, UserEntity creator, PublicationStatus status)
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
            : this(Guid.NewGuid(), name, description, price, filePath, picturePath, tags, creator, PublicationStatus.Unpublished) { }

        public override string ToString()
        {
            return $"Model: {Name}, price : {Prince}, file path : {FilePath}";
        }

    }
}
