using Fantastic3D.DataManager;
using System.Runtime.Serialization;

namespace Fantastic3D.AppModels
{
    /// <summary>
    /// Defines an asset, his price and his associated tags.
    /// </summary>
    [DataContract]
    public class Asset : ObservableModel, IManageable
    {
        public enum PublicationStatus { Unpublished, Published, Rejected, Removed }
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; }
        public float Price { get; set; }
        public string FilePath { get; set; }
        public string PicturePath { get; set; }
        public ICollection<Tag> Tags { get; private set; }
        public PublicationStatus Status { get; set; }
        public User Creator { get; private set; }
        public ICollection<Review> Reviews { get; private set; }

        public Asset()
        {

        }

        public Asset(int id, string name, string description, float price, string filePath, string picturePath, int creatorId, PublicationStatus status, User creator, ICollection<Review> reviews)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            FilePath = filePath;
            PicturePath = picturePath;
            Tags = new List<Tag>();
            Status = status;
            Creator = creator;
            Reviews = reviews;
        }
    }
}
