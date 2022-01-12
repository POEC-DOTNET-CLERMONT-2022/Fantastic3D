// See https://aka.ms/new-console-template for more information
using Fantastic3D.Models;
using Fantastic3D.Persistence;

// This is code dégueulasse, don't put it en prod !

Console.WriteLine("Cette application permet de tester ce qu'on a implémenté hors de tout contexte, pour nous assurer que les éléments sont solides et n'ont pas trop de dépendance.");

var dataHandler = new XmlDataHandler<Tag>();

var tagTypeOne = new TagType("Thématique", true, false);

var maListe = new List<Tag>();
maListe.Add(new Tag("Horreur", tagTypeOne));
maListe.Add(new Tag("Western", tagTypeOne));
maListe.Add(new Tag("Moderne", tagTypeOne));
maListe.Add(new Tag("Sci-fi", tagTypeOne));
maListe.Add(new Tag("Antique", tagTypeOne));

dataHandler.SaveData(maListe);

// Exemple de rendu
// <ArrayOfTag xmlns="http://schemas.datacontract.org/2004/07/Fantastic3D.Models" xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
// <Tag><_name>Horreur</_name><_tagType><IsMandatory>true</IsMandatory><Name>Thématique</Name></_tagType></Tag>
// <Tag><_name>Western</_name><_tagType><IsMandatory>true</IsMandatory><Name>Thématique</Name></_tagType></Tag><Tag><_name>Moderne</_name><_tagType><IsMandatory>true</IsMandatory><Name>Thématique</Name></_tagType></Tag><Tag><_name>Sci-fi</_name><_tagType><IsMandatory>true</IsMandatory><Name>Thématique</Name></_tagType></Tag><Tag><_name>Antique</_name><_tagType><IsMandatory>true</IsMandatory><Name>Thématique</Name></_tagType></Tag></ArrayOfTag>

Console.WriteLine("La Sauvegarde est faite dans " + Environment.CurrentDirectory);

var myLoadedList = new List<Tag>();
dataHandler.LoadData(myLoadedList);

Console.WriteLine("Lecture de la liste récupérée");
foreach (var tag in myLoadedList)
{
    Console.WriteLine(tag.ToString());
}

Console.ReadLine();