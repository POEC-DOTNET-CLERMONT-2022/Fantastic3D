using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Fantastic3D.AppModels;

namespace Fantastic3D.GUI.Utilities
{
    /// <summary>
    /// Allows the navigation
    /// </summary>
    public class Navigator : ObservableModel, INavigator
    {
        private List<Control> _availableViews { get; set; } = new List<Control>();
        private Stack<Control> _previousViews { get; set; } = new Stack<Control>();
        private ContentControl _currentViewControl = new ContentControl();
        public ContentControl CurrentViewControl
        {
            get => _currentViewControl;
            set
            {
                _currentViewControl = value;
                OnNotifyPropertyChanged();
            }
        }
        public bool CanGoBack { get => _previousViews.Any(); }

        public void NavigateTo(Type type)
        {
            if (CurrentViewControl == null) return;
            if (CurrentViewControl.Content != null)
            {
                _previousViews.Push((Control)CurrentViewControl.Content);
            }
            var newView = _availableViews.SingleOrDefault(view => view.GetType() == type);
            if (newView == null) return;
            _currentViewControl.Content = newView;
        }

        public void RegisterViews(ICollection<Control> views)
        {
            _availableViews.AddRange(views);
        }

        public bool TryGoBack()
        {   
            if(CanGoBack || CurrentViewControl == null)
                return false;
            CurrentViewControl.Content = _previousViews.Pop();
                return true;
        }
    }
}
