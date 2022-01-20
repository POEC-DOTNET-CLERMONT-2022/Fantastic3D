using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantastic3D.DataManager;
namespace Fantastic3D.AppModels
{
    public class Review : ObservableModel, IManageable
    {
        public int Id { get; set; }
        public int Note { get; set; }
        public string Comment { get; set; }
        private bool IsPublished { get; set; }
        public int Asset { get; set; }
        public int Author { get; set; }
        public Review(int id, int note, string comment, bool isPublished, int asset, int author)
        {
            Id = id;
            Note = note;
            Comment = comment;
            IsPublished = isPublished;
            Asset = asset;
            Author = author;
        }
        public override string ToString()
        {
            return $"Note : {Note}, Commentaire :{Comment}, Publié ?{IsPublished}, Asset :{Asset}, Auteur:{Author} ";
        }

    }
}
