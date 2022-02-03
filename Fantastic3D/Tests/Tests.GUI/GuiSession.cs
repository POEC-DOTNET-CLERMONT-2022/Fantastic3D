using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.Tests.GUI
{
    public class GuiSession
    {
        // Note: append /wd/hub to the URL if you're directing the test at Appium
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4727";
        // Path.GetFullPath(Path.Combine(AppContext.BaseDirectory
        private const string AppPath = @"Z:\Repos\DevOpsFormation\Projet\Fantastic3D\Fantastic3D.WPFApp\bin\Debug\net6.0-windows\App.Fantastic3DManager.exe";

        protected static WindowsDriver<WindowsElement> session;

        public static void Setup(TestContext context)
        {
            // Launch Calculator application if it is not yet launched
            if (session == null)
            {
                var options = new AppiumOptions();
                options.AddAdditionalCapability("app", AppPath);
                options.AddAdditionalCapability("deviceName", "WindowsPC");
                    
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), options);

                Assert.IsNotNull(session);

                // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
                session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            }
        }

        public static void TearDown()
        {
            // Close the application and delete the session
            if (session != null)
            {
                session.Quit();
                session = null;
            }
        }
    }
}
