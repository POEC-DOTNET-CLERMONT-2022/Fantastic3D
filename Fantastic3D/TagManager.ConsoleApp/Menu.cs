using Fantastic3D.Persistence.Entities;

namespace Fantastic3D.Tags
{
    internal class Menu
    {
        private IReader _reader;
        private IWriter _writer;
        private TagManager _tagManager;
        private List<TagType> _tagTypes;

        public Menu(IReader reader, IWriter writer, TagManager tagManager, List<TagType> tagTypes)
        {
            _reader = reader;
            _reader.Writer = writer;
            _writer = writer;
            _tagManager = tagManager;
            _tagTypes = tagTypes;
        }


        /// <summary>
        ///  Print Main menu and wait for user input
        /// </summary>
        public void ShowMainMenu()
        {
            _writer.SetAppTitle("Tag Crud");
            _writer.SetMenuHeader(" Menu Principal." + Environment.NewLine );

            _writer.Display(
                "1. Liste des Tags." + Environment.NewLine +
                "2. Ajouter un Tag." + Environment.NewLine +
                "3. Editer un Tag." + Environment.NewLine +
                "4. Supprimer un Tag." + Environment.NewLine +
                "5. Quit().");
            GetMainMenuInput();
        }

        /// <summary>
        /// Get the user input from the main menu and call submenu 
        /// </summary>
        public void GetMainMenuInput()
        {
            var UserInputInt = _reader.ReadId(1, 5);
            switch (UserInputInt)
            {
                case 1:
                    ShowMenuList();
                    break;
                case 2:
                    ShowAddMenu();
                    break;
                case 3:
                    ShowEditMenu();
                    break;
                case 4:
                    ShowDeleteMenu();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }


        /// <summary>
        /// Print the tag list 
        /// </summary>
        public void ShowMenuList()
        {
            _writer.SetAppTitle("Tag Crud");
            _writer.SetMenuHeader(" Menu List de Tag(s)." + Environment.NewLine);

            _tagManager.LoadList();
            int i = 0;
            foreach (Tag mytag in _tagManager.listTag)
            {
                i++;
                _reader.Writer.Display(i.ToString() + ". " + mytag);
            }
            _writer.Display("\nEntrer une touche pour continuer ");
            var waitUser = _reader.ReadText();
        }
        /// <summary>
        /// Print Menu Add, and get user input for add tag
        /// </summary>
        public void ShowAddMenu()
        {
            _writer.SetAppTitle("Tag Crud");
            _writer.SetMenuHeader(" Menu Add Tag" + Environment.NewLine);
            var retrievedTag = _reader.GetElementFromList(_tagTypes, "Quel est le type de ce tag ?");
            _writer.Display($"Entrer nom du nouveau tag (de type {retrievedTag.Name}) :");
            var TagName = _reader.ReadText();
            _tagManager.Add(TagName, retrievedTag);
            _writer.Display("\nLe tag à bien etait ajouté ");
            _writer.Display("Entrer une touche pour continuer ");
            var waitUser = _reader.ReadText();
        }


        /// <summary>
        /// Print the tag list and get user input id for delete the tag
        /// </summary>
        public void ShowDeleteMenu()
        {
            _writer.SetAppTitle("Tag Crud");
            _writer.SetMenuHeader(" Menu Delete Tag" + Environment.NewLine);
            ShowMenuList();
            int tagCount = _tagManager.GetTagListCount() ;
            _writer.Display("Entrer l'id du tag pour le supprimer :");
           int tagTypeId = _reader.ReadId(1, tagCount  );
            _tagManager.Delete(tagTypeId -1);
            _writer.Display("\nLe tag à bien etait supprimé ");
            _writer.Display("Entrer une touche pour continuer ");
            var waitUser = _reader.ReadText();

        }

        /// <summary>
        /// Print the tag list and get user input id for edit the tag
        /// </summary>
        public void ShowEditMenu()
        {
            _writer.SetAppTitle("Tag Crud");
            _writer.SetMenuHeader(" Menu EditerTag" + Environment.NewLine);
            ShowMenuList();
            int tagCount = _tagManager.GetTagListCount();
            _writer.Display("Entrer l'id du tag pour l'editer :");
            int tagTypeId = _reader.ReadId(1, tagCount);
            _writer.Display("Veuillez saisir le nouveau nom du tag");
            var inputName = _reader.ReadText();
            _tagManager.EditName(tagTypeId - 1, inputName);
            _writer.Display("\nLe tag à bien etait édité ");
            _writer.Display("Entrer une touche pour continuer ");
            var waitUser = _reader.ReadText();
        }
    }
}
