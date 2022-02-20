using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.AppModels
{
    public class OrderList : ObservableModel
    {
        private ObservableCollection<Order> orders;

        private Order currentOrder;
        public Order CurrentOrder
        {
            get { return currentOrder; }
            set
            {
                if (currentOrder != value)
                {
                    currentOrder = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<Order> Orders
        {
            get { return orders; }
            set
            {
                if (orders != value)
                {
                    orders = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

    }
}
