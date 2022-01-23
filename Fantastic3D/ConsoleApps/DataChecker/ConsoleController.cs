using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataChecker
{
    internal class ConsoleController
    {
        private string _appTitle;

        public ConsoleController(string appTitle)
        {
            _appTitle = appTitle;
        }

        public void Display(string text)
        {
            Console.WriteLine(text);
        }

        public void ClearAndShowTitle()
        {
            Console.Clear();
            var previousForegroundColor = Console.ForegroundColor;
            var previousBackgroundColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"***** {_appTitle} *****");
            Console.ForegroundColor = previousForegroundColor;
            Console.BackgroundColor = previousBackgroundColor;
        }

    }
}
