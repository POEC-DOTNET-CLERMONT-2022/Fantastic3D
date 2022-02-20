using Fantastic3D.AppModels;
using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using Fantastic3D.GUI.Utilities;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour OrderViewControl.xaml
    /// </summary>
    public partial class OrderViewControl : UserControl
    {
        public List<Order> OrderToValidate { get; set; } = new();
        public IDataManager<Order, OrderDto> _dataSource = ((App)Application.Current).Services.GetService<IDataManager<Order, OrderDto>>();
        

        public static readonly DependencyProperty CurrentOrderProperty =
            DependencyProperty.Register(nameof(EditableOrder), typeof(Order), typeof(OrderViewControl));

        private Order editableOrder;
        public Order EditableOrder
        {
            get { return GetValue(CurrentOrderProperty) as Order; }
            set
            {
                if (editableOrder != value)
                {
                    SetValue(CurrentOrderProperty, value);
                }
            }
        }
        public OrderViewControl()
        {
            InitializeComponent();
            OrderToValidate = new List<Order>();
            DataContext = OrderToValidate;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Navigator.NavigateTo(typeof(OrderListControl));
        }
        private void ViewUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Tag != null && ((Button)sender).Tag is int userId)
            {
                ((MainWindow)Application.Current.MainWindow)
                    .Navigator.NavigateTo(typeof(UserViewControl), userId);
            }
        }
    }
}
