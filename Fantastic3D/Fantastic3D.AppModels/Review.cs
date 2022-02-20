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
        public bool IsPublished { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public override string ToString()
        {
            return $"Note : {Note}, Commentaire :{Comment}, Publié ?{IsPublished}, Asset :{AssetName}, Auteur:{AuthorName} ";
        }

    }
}
