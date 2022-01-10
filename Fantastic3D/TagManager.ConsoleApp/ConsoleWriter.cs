// See https://aka.ms/new-console-template for more information
using Fantastic3D.Models;
using Fantastic3D.Tags;

internal class ConsoleWriter : IWriter
{
    void IWriter.Display(string text)
    {
        Console.WriteLine(text);
    }

    void IWriter.DisplayTag(Tag tag)
    {
        Console.WriteLine(tag);
    }
}