namespace Fantastic3D.Tags
{
    internal class ConsoleWriter : IWriter
    {
        private string _appTitle = "";
        private string _menuSectionTitle = "";
        public void Display(string text)
        {
            Console.WriteLine(text);
        }

        public void SetAppTitle(string title)
        {
            _appTitle = title;
            Console.Clear();
            Console.WriteLine(_appTitle);
        }

        public void SetMenuHeader(string sectionHeader)
        {
            _menuSectionTitle = sectionHeader;
            Console.WriteLine(_menuSectionTitle);
        }

        public void DisplayTag(Fantastic3D.Persistence.Entities.TagEntity tag)
        {
            Console.WriteLine(tag);
        }
    }
}