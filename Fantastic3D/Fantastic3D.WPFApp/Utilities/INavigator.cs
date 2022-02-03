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

    }
}
