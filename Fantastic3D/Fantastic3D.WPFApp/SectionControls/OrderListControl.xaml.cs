using Fantastic3D.AppModels;
using Fantastic3D.DataManager;
using Fantastic3D.Dto;
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
    /// Logique d'interaction pour OrderListControl.xaml
    /// </summary>
    public partial class OrderListControl : UserControl
    {
        public ObservableList<Order> OrdersList { get; set; } = new ObservableList<Order>();
        public IDataManager<Order, OrderDto> _dataSource = ((App)Application.Current).Services.GetService<IDataManager<Order, OrderDto>>();

        public OrderListControl()
        {
            InitializeComponent();
        }
    }
}
