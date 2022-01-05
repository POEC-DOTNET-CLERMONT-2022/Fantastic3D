// See https://aka.ms/new-console-template for more information
using Fantastic3D.Models;

Console.WriteLine("Hello, World!");

var allTagTypes = new List<TagType>()
{
    new TagType("Thématique", true, false),
    new TagType("Catégories", true, false),
    new TagType("Style", false, false),
    new TagType("Format", false, isOnlyOne:true),
    new TagType("Licence", false, isOnlyOne:true),
    new TagType("Capacités", false, false),
};

foreach (var tagType in allTagTypes)
{
    Console.WriteLine("- " + tagType.Name);
}