using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Define the review, the asset and ihs autor, the note and the comment associed
    /// and if it's published or not
    /// </summary>
    [DataContract]
    public class ReviewEntity : IPersistable
    {
        [DataMember]
        [Key]
        public Guid Id { get; set; }
        public int Note { get; set; }
        public string Comment { get; set; }
        public bool IsPublished { get; set; }
        public AssetEntity Asset { get; set; }
        public UserEntity Author { get; set; }
        public ReviewEntity(Guid id, int note, string comment, bool isPublished, AssetEntity asset, UserEntity autorUser)
        {
            Id = id;
            Note = note;
            Comment = comment;
            IsPublished = isPublished;
            Asset = asset;
            Author = autorUser;
        }

        public override string ToString()
        {
            return $"Note : {Note}, Commentaire : {Comment}, Publié : {IsPublished}, Asset : {Asset}, Author : {Author}";
        }
    }

}
