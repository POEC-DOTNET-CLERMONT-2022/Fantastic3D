// See https://aka.ms/new-console-template for more information
using Fantastic3D.Models;
using Fantastic3D.Persistence;
using Fantastic3D.Tags;


// TODO : les types de tag sont codés en dur. Faire un import depuis persistance.
//var allTagTypes = new List<TagType>()
//{
//    new TagType("Thématique", true, false),
//    new TagType("Catégories", true, false),
//    new TagType("Style", false, false),
//    new TagType("Format", false, isOnlyOne:true),
//    new TagType("Licence", false, isOnlyOne:true),
//    new TagType("Capacités", false, false),
//};

var allTagTypes = new List<TagType>();
var dummyDataMaker = new DummyDataHandler<TagType>();
dummyDataMaker.LoadData(allTagTypes);

var tagManager = new TagManager(new ConsoleReader(), new ConsoleWritter(), new DummyDataHandler<Tag>(), allTagTypes);

var mainMenu = new Menu(new ConsoleReader(), new ConsoleWritter(), tagManager, allTagTypes);

bool WeContinue = true;

do
{
    mainMenu.ShowMainMenu();

} while (WeContinue);
