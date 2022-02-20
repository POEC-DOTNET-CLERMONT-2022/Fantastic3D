using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.GUI.SectionControls
{
    /// <summary>
    /// Interface for views where the contents can be loaded through a simple id.
    /// </summary>
    internal interface IContentLoadableById
    {
        public void LoadContentById(int id);
    }
}
