using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void TestButton()
        {
            Thread.Sleep(5000);
            session.FindElementByAccessibilityId("MenuUsersButton").Click();
            
            Thread.Sleep(5000);
            session.FindElementByAccessibilityId("MenuModelButton").Click();
        }
    }
}