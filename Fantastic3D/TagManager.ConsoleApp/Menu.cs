

using Fantastic3D.Models;

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
        /// Get the user input from the main menu and call submenu or function
        /// </summary>
        public void GetMainMenuInput()
        {
            var UserInputInt = _reader.ReadId(1, 5);
            switch (UserInputInt)
            {
                case 1:
                    _tagManager.ShowList();
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
        /// Print Menu Add, and get user input for add tag
        /// </summary>
        public void ShowAddMenu()
        {
            _writer.Display("Menu Add Tag.");
            var retrievedTag = _reader.GetElementFromList(_tagTypes, "Quel est le type de ce tag ?");
            //var displayedLines = new List<string>();
            //var keyToPress = 0;

            //foreach (TagType tagType in _tagTypes)
            //{
            //    displayedLines.Add($"{keyToPress++} : {tagType.Name}");
            //}
            //_writer.Display(string.Join(Environment.NewLine, displayedLines));

            //int tagTypeId = _reader.ReadId(0, keyToPress - 1);

            _writer.Display($"Entrer nom du nouveau tag (de type {retrievedTag.Name}) :");
            var TagName = _reader.ReadText();

            _tagManager.Add(TagName, retrievedTag);
        }


        /// <summary>
        /// Print the tag list and get user input id for delete the tag
        /// </summary>
        public void ShowDeleteMenu()
        {
            _tagManager.ShowList();
            int tagCount = _tagManager.GetTagListCount() ;
            _writer.Display("Entrer lid du tag pour le supprimer :");
           int tagTypeId = _reader.ReadId(1, tagCount  );
            _tagManager.Delete(tagTypeId -1);
        }

        /// <summary>
        /// Print the tag list and get user input id for edit the tag
        /// </summary>
        public void ShowEditMenu()
        {
            _tagManager.ShowList();
            int tagCount = _tagManager.GetTagListCount();
            _writer.Display("Entrer lid du tag pour l'editer :");
            int tagTypeId = _reader.ReadId(1, tagCount);
            _tagManager.EditName(tagTypeId - 1);
        }
    }
}
