using Fantastic3D.DataManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.AppModels
{
    public  class ObservableList<T> : ObservableModel
        where T : IManageable, new()
    {
        private ObservableCollection<T> items;

        private T currentItem;
        public T CurrentItem
        {
            get { return currentItem; }
            set
            {
                if (currentItem != null || !currentItem.Equals(value))
                {
                    currentItem = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<T> Items
        {
            get { return items; }
            set
            {
                if (items != value)
                {
                    items = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
