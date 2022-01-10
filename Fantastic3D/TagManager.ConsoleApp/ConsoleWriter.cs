// See https://aka.ms/new-console-template for more information
using Fantastic3D.Models;
using Fantastic3D.Tags;

internal class ConsoleWriter : IWriter
{
    private string _appTitle = "";
    private string _menuSectionTitle = "";
    void IWriter.Display(string text)
    {
        Console.WriteLine(text);
    }

    void IWriter.SetAppTitle(string title)
    {
        _appTitle = title;
        Console.Clear();
        Console.WriteLine(_appTitle);
    }

    void IWriter.SetMenuHeader(string sectionHeader)
    {
        _menuSectionTitle = sectionHeader;
        Console.Clear();
        Console.WriteLine(_appTitle);
        Console.WriteLine(_menuSectionTitle);
    }

    void IWriter.DisplayTag(Tag tag)
    {
        Console.WriteLine(tag);
    }
}