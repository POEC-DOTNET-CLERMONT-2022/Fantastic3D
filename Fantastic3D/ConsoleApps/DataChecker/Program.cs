// See https://aka.ms/new-console-template for more information
using App.DataChecker;
using Fantastic3D.Dto;
using Fantastic3D.Persistence;
using Fantastic3D.Persistence.Entities;

#region Xml Data
const string dataPathFromConsoleApp = @"..\..\..\..\..\Data\";
var xmlDataHandler = new XmlDataHandler<TagTypeEntity>(dataPathFromConsoleApp);

#endregion

var console = new ConsoleController("Fantastic3D Data Checker");
console.ClearAndShowTitle();

console.Display("Application permettant la vérification des données et leur passage d'un système de données à un autre.");
console.Display("La Sauvegarde XML est faite dans " + xmlDataHandler.GetPath);

console.Display("Lecture de la liste récupérée (Dummy)");

List<Type> typesToFetch = new List<Type> { typeof(UserDto), typeof(TagTypeDto), typeof(TagDto), typeof(AssetDto), typeof(PurchaseDto), typeof(OrderDto), typeof(ReviewDto), };
var dummyDataHandler = new DummyDataHandler<TagTypeEntity>();
var dummyLoadedList = new List<TagTypeEntity>();
dummyDataHandler.LoadData(dummyLoadedList);
foreach (var item in dummyLoadedList)
{
    console.Display(item.ToString());
}

console.Display("Lecture de la liste récupérée (Xml)");
var xmlLoadedList = new List<TagTypeEntity>();
xmlDataHandler.LoadData(xmlLoadedList);
foreach (var item in xmlLoadedList)
{
    console.Display(item.ToString());
}
Console.ReadLine();