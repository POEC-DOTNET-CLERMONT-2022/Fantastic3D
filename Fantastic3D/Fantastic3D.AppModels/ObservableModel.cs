using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Fantastic3D.AppModels
{
    public class ObservableModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Invoke this when a property is changed on the GUI
        /// </summary>
        /// <param name="propertyname"></param>
        protected virtual void OnNotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}