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

        public TagManager(IReader reader, IWriter writer, IDataHandler dataHandler)
        {
            _reader = reader;
            _reader.Writer = writer;
            _writer = writer;

            _dataHandler = dataHandler;
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

        /// <summary>
        ///  Affiche le menu pricipal et atten un input
        /// </summary>
        public void ShowMainMenu()
        {
            _writer.Display(
                "Menu Principal." + Environment.NewLine +
                "1. Liste des Tags." + Environment.NewLine +
                "2. Ajouter un Tag." + Environment.NewLine +
                "3. Editer un Tag." + Environment.NewLine +
                "4. Supprimer un Tag." + Environment.NewLine +
                "5. Quit().");
            GetMainMenuInput();
        }

        /// <summary>
        /// Affiche le menu pour add un tag et renvoie le tag creer ver la methode pour l'ajout
        /// </summary>
        public void ShowAddMenu()
        {
            _writer.Display(
                "\nMenu Add Tag." + Environment.NewLine +
                "Entrer nom du nouveau tag :" + Environment.NewLine );
            var TagName = _reader.ReadText();

            _writer.Display("Quel est le nom du type de tag :" + Environment.NewLine);
            var TagTypeName = _reader.ReadText();

            _writer.Display("Le Tag est'il mendaté ? 1 Oui - 2 Non." + Environment.NewLine);
            var getTagMendatory = _reader.ReadId(1, 2);
            bool tagMendatory = false;
            switch(getTagMendatory)    
            {
                case 1:
                    tagMendatory = true;
                    break;
                case 2:
                    tagMendatory = false;
                    break;
            }

            Console.WriteLine(tagMendatory);
            _writer.Display("Le Tag peu etre utilisé plusieurs fois ? Oui/Non." + Environment.NewLine);
            var getTagOnlyOne = _reader.ReadId(1,2);
            bool TagOnlyOne = true;
            switch(getTagOnlyOne)
            {
                case 1:
                    TagOnlyOne = false;
                    break;
                case 2:
                    TagOnlyOne = true;
                    break;
            }
            Console.WriteLine(TagOnlyOne);

            TagType TagType = new TagType(TagTypeName, tagMendatory, TagOnlyOne);
            Tag newTag = new Tag(TagName, TagType);

            Add(TagName, TagType);
        }

        public void GetMainMenuInput()
        {
            var UserInputInt = _reader.ReadId(1 , 5);
            switch (UserInputInt)
            {
                case 1:
                    ShowList();
                    break;
                case 2:
                    ShowAddMenu();
                    break;
                case 3:
                    //ShowEditMenu();
                    break;
                case 4:
                    //ShowDeeteMenu();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;

            }
        }
    }
}
