
namespace Fantastic3D.Models
{
    /// <summary>
    /// Define the review, the asset and ihs autor, the note and the comment associed
    /// and if it's published or not
    /// </summary>
    public class Review
    {
        private Guid _id;
        private int _note;
        private string _comment;
        private bool _isPublished;
        private Asset _asset;
        private User _author;
        public Review(Guid id, int note, string comment, bool isPublished, Asset asset, User autorUser)
        {
            _id = id;
            _note = note;
            _comment = comment;
            _isPublished = isPublished;
            _asset = asset;
            _author = autorUser;
        }

        public override string ToString()
        {
            return $"Note : {_note}, Commentaire : {_comment}, Publié : {_isPublished}, Asset : {_asset}, Author : {_author}";
        }
    }

}
