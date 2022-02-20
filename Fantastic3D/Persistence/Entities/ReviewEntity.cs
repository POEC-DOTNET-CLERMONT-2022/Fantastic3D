using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fantastic3D.DataManager;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Define the review, the asset and ihs autor, the note and the comment associed
    /// and if it's published or not
    /// </summary>
    [Table("Review")]
    public class ReviewEntity : IManageable
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Note { get; set; }
        public string Comment { get; set; }
        public bool IsPublished { get; set; }
        public int AssetId { get; set; }
        public int AuthorId { get; set; }
        public virtual AssetEntity Asset { get; set; }
        public virtual UserEntity Author { get; set; }

        public ReviewEntity(){}

        public ReviewEntity(int note, string comment, bool isPublished, int assetId, int authorId)
        {
            Note = note;
            Comment = comment;
            IsPublished = isPublished;
            AssetId = assetId;
            AuthorId = authorId;
        }
    }

}
