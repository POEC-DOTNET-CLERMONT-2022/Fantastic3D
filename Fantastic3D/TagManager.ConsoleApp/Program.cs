﻿// See https://aka.ms/new-console-template for more information
using Fantastic3D.Persistence.Entities;
using Fantastic3D.Persistence;
using Fantastic3D.Tags;

var allTagTypes = new List<TagType>();
var dummyDataMaker = new DummyDataHandler<TagType>();
dummyDataMaker.LoadData(allTagTypes);

var tagReader = new ConsoleReader();
var tagWriter = new ConsoleWriter();

var tagManager = new TagManager(new XmlDataHandler<Tag>(), allTagTypes);
var mainMenu = new Menu( tagReader, tagWriter, tagManager, allTagTypes);

bool WeContinue = true;

do
{
    mainMenu.ShowMainMenu();

} while (WeContinue);
