using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.Models
{
    /// <summary>
    /// Define the review, the note added, the comment and if he's published or not
    /// </summary>
    public class Review
    {
        public Guid _uniqueId;
        public int _note;
        public string _comment;
        public bool _isPublished;

        public Review(Guid uniqueId, int note, string comment, bool isPublished)
        {
            _uniqueId = Guid.NewGuid();
            _note = note;
            _comment = comment;
            _isPublished = isPublished;
        }

        public override string ToString()
        {
            return $"Note : {_note} Commentaire : {_comment} Publié : {_isPublished})";
        }
    }

}
