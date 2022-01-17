using System.Runtime.Serialization;

namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Define the review, the asset and ihs autor, the note and the comment associed
    /// and if it's published or not
    /// </summary>
    [DataContract]
    public class Review : IPersistable
    {
        [DataMember]
        private Guid _id;
        [DataMember]
        private int _note;
        [DataMember]
        private string _comment;
        [DataMember]
        private bool _isPublished;
        [DataMember]
        private Asset _asset;
        [DataMember]
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
