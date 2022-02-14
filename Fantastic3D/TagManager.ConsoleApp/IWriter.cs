using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantastic3D.Persistence.Entities;

namespace Fantastic3D.Tags
{
    // On ne touche pas les contrats, sinon ça rend un chaton triste !
    internal interface IWriter
    {
        /// <summary>
        /// Displays any string of text.
        /// </summary>
        public void Display(string text);
        /// <summary>
        /// Displays an object of the Tag type
        /// </summary>
        public void DisplayTag(TagEntity tag);
        /// <summary>
        /// Changes the title of the app
        /// </summary>
        public void SetAppTitle(string title);
        /// <summary>
        /// Clears the screen and change the title of the current menu section
        /// </summary>
        public void SetMenuHeader(string sectionHeader);

    }
}
