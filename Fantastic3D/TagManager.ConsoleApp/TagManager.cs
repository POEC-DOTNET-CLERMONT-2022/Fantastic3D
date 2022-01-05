using Fantastic3D.Models;
using Fantastic3D.Persistence;

namespace Fantastic3D.Tags
{
    /// <summary>
    /// Operations of Add, Delete, Update, and list for the application tags.
    /// </summary>
    internal class TagManager
    {
        private IReader _reader;
        private IWriter _writer;
        private IDataHandler _dataHandler;
        private List<Tag> listTag = new List<Tag>();

        public TagManager(IReader reader, IWriter writer)
        {
            _reader = reader;
            _reader.Writer = writer;
            _writer = writer;
        }


        public void Add(string Name,  TagType tagType) 
        { // la verif que le tag nexiste pas deja
            var mytag = new Tag(Name, tagType);
            listTag.Add( mytag );
            _dataHandler.SaveData("tags", listTag);
        }

        public void ShowList()
        {
            if(listTag.Count == 0)
            {
                try
                {
                    listTag = (List<Tag>)_dataHandler.LoadData("tags");
                }
                catch (Exception ex)
                {

                }
            }

            int i = 0;
            foreach (Tag mytag in listTag)
            {
                i++;
                _reader.Writer.Display(i.ToString() + mytag);
            }
        }
        public void Delete(int tagId)
        {
            // delete a parti d'un num, 1. tag
            // il aura qua selectioner un chiffre pour supp le tag corespondant

            listTag.RemoveAt(tagId);
        }
        public void EditName(int tagId)
        {
            
            _writer.Display("Veuillez saisir le nouveau nom du tag");
            var inputName = _reader.ReadText();
            listTag[tagId].Rename(inputName);


        }
    }
}
