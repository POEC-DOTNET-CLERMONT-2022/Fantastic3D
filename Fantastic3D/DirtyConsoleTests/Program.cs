// See https://aka.ms/new-console-template for more information
using Fantastic3D.Models;
using Fantastic3D.Persistence;

Console.WriteLine("Hello, World!");

Console.WriteLine("Cette application permet de tester ce qu'on a implémenté hors de tout contexte, pour nous assurer que les éléments sont solides et n'ont pas trop de dépendance.");

var dataHandler = new XMLDataHandler();

var tagTypeOne = new TagType("Thématique", true, false);

var maListe = new List<Tag>();
maListe.Add(new Tag("Horreur", tagTypeOne));
maListe.Add(new Tag("Western", tagTypeOne));
maListe.Add(new Tag("Moderne", tagTypeOne));
maListe.Add(new Tag("Sci-fi", tagTypeOne));
maListe.Add(new Tag("Antique", tagTypeOne));

dataHandler.SaveData("tags", maListe);

Console.WriteLine("La Sauvegarde est faite dans " + Environment.CurrentDirectory);

var myLoadedList = (List<Tag>)dataHandler.LoadData("tags");

Console.WriteLine("Lecture de la liste récupérée");
foreach(var tag in myLoadedList)
{
    Console.WriteLine(tag.ToString());
}

Console.ReadLine();