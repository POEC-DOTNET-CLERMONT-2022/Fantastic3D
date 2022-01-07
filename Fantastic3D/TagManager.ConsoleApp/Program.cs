// See https://aka.ms/new-console-template for more information
using Fantastic3D.Models;
using Fantastic3D.Persistence;
using Fantastic3D.Tags;

Console.WriteLine("Hello, World!");


// TODO : les types de tag sont codés en dur. Faire un import depuis persistance.
var allTagTypes = new List<TagType>()
{
    new TagType("Thématique", true, false),
    new TagType("Catégories", true, false),
    new TagType("Style", false, false),
    new TagType("Format", false, isOnlyOne:true),
    new TagType("Licence", false, isOnlyOne:true),
    new TagType("Capacités", false, false),
};

var tagManager = new TagManager(new ConsoleReader(), new ConsoleWritter(), new XMLDataHandler(), allTagTypes);

bool WeContinue = true;

do
{
    tagManager.ShowMainMenu();

}while (WeContinue);