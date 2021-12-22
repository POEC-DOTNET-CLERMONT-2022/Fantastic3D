using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The3DModelWebsite.Tags
{
    /// <summary>
    /// Operations of Add, Delete, Update, and list for the application tags.
    /// </summary>
    internal class TagManager
    {
        private readonly List<Tag> listeTag = new List<Tag>();
        public void Add(string Name,  TagType tagType ) 
        {
            var montag = new Tag(Name, tagType);
            listeTag.Add( montag );

        }
        public void VoirListe()
        {
            foreach (Tag montag in listeTag)
            {

            }
        }
        public void Delete(string Name, TagType tagType)
        {
            //listeTag.Where( x =>  x.name == Name);
        }
        public void EditName()
        {

        }
    }
}
