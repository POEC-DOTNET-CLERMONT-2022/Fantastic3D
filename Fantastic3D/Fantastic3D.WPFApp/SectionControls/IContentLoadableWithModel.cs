using Fantastic3D.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.GUI.SectionControls
{
    /// <summary>
    /// Describes a view containing a single IManageable Model
    /// </summary>
    public interface IContentLoadableWithModel
    {
        public void LoadContentWithModel(IManageable modelInstance);
    }
}
