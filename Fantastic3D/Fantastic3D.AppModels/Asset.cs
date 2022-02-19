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
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string FilePath { get; set; }
        public string PicturePath { get; set; }
        public ICollection<Tag> Tags { get; private set; }
        public PublicationStatus Status { get; set; }
        public string CreatorName { get; set; }
        public int CreatorId { get; set; }
        //public ICollection<Review> Reviews { get; private set; }

        public Asset()
        {

        }
    }
}
