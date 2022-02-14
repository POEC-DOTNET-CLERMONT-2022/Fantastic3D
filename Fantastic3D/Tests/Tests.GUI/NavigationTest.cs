using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;

namespace Fantastic3D.Tests.GUI
{
    [TestClass]
    public class NavigationTest : GuiSession
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Setup(context);
        }
        /// <summary>
        /// This checks if all the buttons are correctly labeled.
        /// </summary>
        [TestMethod]
        public void TestButton()
        {
            var buttonLabels = new List<string> {
                "Accueil",
                "Modèles",
                "Utilisateurs",
                "Commandes",
                "Avis"
            };
            Thread.Sleep(5000);
            
            foreach(var buttonLabel in buttonLabels)
            { 
                var usersButton = session.FindElementsByName(buttonLabel);
                if (usersButton.Count == 0)
                {
                    Assert.Fail($"Aucun bouton avec le label [{buttonLabel}] n'a été trouvé.");
                }
                else
                {
                    usersButton[0].Click();
                }
            }
        }
    }
}