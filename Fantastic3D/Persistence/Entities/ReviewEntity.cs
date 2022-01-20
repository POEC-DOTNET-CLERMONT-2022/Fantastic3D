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
        [Key, Required]
        public int Id { get; set; }
        public int Note { get; set; }
        public string Comment { get; set; }
        public bool IsPublished { get; set; }

        public int AssetId { get; set; }
        public int AuthorId { get; set; }
        public virtual AssetEntity Asset { get; private set; }
        public virtual UserEntity Author { get; private set; }

        public ReviewEntity(){}
    }

}
