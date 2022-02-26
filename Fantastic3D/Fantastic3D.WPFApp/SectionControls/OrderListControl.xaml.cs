using Fantastic3D.AppModels;
using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fantastic3D.GUI.SectionControls
{
    /// <summary>
    /// Logique d'interaction pour OrderListControl.xaml
    /// </summary>
    public partial class OrderListControl : UserControl, IContentLoadableById
    {
        //public ObservableList<Order> OrdersList { get; set; } = new ObservableList<Order>();
        public OrderList OrdersList { get; set; } = new OrderList();
        public IDataManager<Order, OrderDto> _dataSource = ((App)Application.Current).Services.GetService<IDataManager<Order, OrderDto>>();
        private int _filterId = 0;

        private DateTime _OrderDate = DateTime.Now;
        public OrderListControl()
        {
            InitializeComponent();
            DataContext = OrdersList;
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Navigator.NavigateTo(typeof(OrderViewControl));
            ((OrderViewControl)((MainWindow)Application.Current.MainWindow).Navigator.CurrentViewControl.Content).EditableOrder = OrdersList.CurrentOrder;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadOrders();
        }
        private async void LoadOrders()
        {
            try
            {
                var Orders = await _dataSource.GetAllAsync();
                if (Orders != null && Orders.Any())
                {
                    OrdersList.Orders = new ObservableCollection<Order>(Orders);
                }
                else
                {
                    MessageBox.Show($"Aucune commande trouvée. La base de donnée est peut-être vide ou l'API est innaccessible.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Source de données non accessible", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void CollectionViewSource_OnFilter(object sender, FilterEventArgs e)
        {
            var order = e.Item as Order;

            if (order.PurchasingUserId == _filterId || _filterId == 0)
            {
                e.Accepted = true;
                return;
            }

            e.Accepted = false;
        }

        private void ClearFilter()
        {
            _filterId = 0;
            LoadOrders();
        }

        public void LoadContentByDate()
        {
            _OrderDate = (DateTime)DatePicker.SelectedDate;
        }
        public void LoadContentById(int id)
        {
            _filterId = id;
            LoadOrders();
        }
    }
}
