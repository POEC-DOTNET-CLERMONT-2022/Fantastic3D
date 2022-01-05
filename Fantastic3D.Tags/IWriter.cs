using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.Tags
{
    internal interface IWriter
    {
        /// <summary>
        /// Displays any string of text.
        /// </summary>
        internal void Display(string text);
        /// <summary>
        /// Displays an object of the Tag type
        /// </summary>
        internal void DisplayTag(Tag tag);
    }
}
