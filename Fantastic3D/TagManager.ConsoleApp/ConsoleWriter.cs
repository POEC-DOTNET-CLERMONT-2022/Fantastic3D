namespace Fantastic3D.Tags
{
    internal class ConsoleWriter : IWriter
    {
        private string _appTitle = "";
        public void Display(string text)
        {
            Console.WriteLine(text);
        }

        private void ClearAndShowTitle()
        {
            Console.Clear();
            var previousForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"***** {_appTitle} *****");
            Console.ForegroundColor = previousForegroundColor;
        }

        public void SetAppTitle(string title)
        {
            _appTitle = title;
            ClearAndShowTitle();
        }

        public void SetMenuHeader(string sectionHeader)
        {
            ClearAndShowTitle();
            Console.WriteLine(sectionHeader);
        }

        public void DisplayTag(Fantastic3D.Persistence.Entities.TagEntity tag)
        {
            Console.WriteLine(tag);
        }
    }
}