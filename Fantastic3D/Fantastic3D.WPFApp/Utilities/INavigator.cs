using Fantastic3D.DataManager;
using Fantastic3D.GUI.SectionControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Fantastic3D.GUI.Utilities
{
    public interface INavigator
    {
        ContentControl CurrentViewControl { get; set; }
        bool CanGoBack { get; }

        void RegisterViews(ICollection<Control> views);

        void NavigateTo(Type type);
        void NavigateTo(Type viewWithContent, int id);
        void NavigateTo(Type viewWithContent, IManageable modelInstance);

    }
}
