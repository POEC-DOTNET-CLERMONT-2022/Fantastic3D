using Fantastic3D.GUI.SectionControls;
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

namespace Fantastic3D.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public INavigator Navigator { get; } = new Navigator();
        public MainWindow()
        {
            InitializeComponent();

            Navigator.RegisterViews(new List<Control>()
            {
                new ModelViewerControl(),
                new ModelListControl(),
                new HomeScreenControl(),
                new ReviewControl(),
                new UserListControl(),
                new UserViewControl(),
                new OrderListControl(),
                new OrderViewControl()
            });
            Navigator.CurrentViewControl = MainContent;

            Navigator.NavigateTo(typeof(HomeScreenControl));
        }

        private void MenuHomeButton_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(HomeScreenControl));
        }

        private void MenuModelButton_Click(object sender, RoutedEventArgs e)
        {

            Navigator.NavigateTo(typeof(ModelListControl), null);
        }

        private void MenuUsersButton_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(UserListControl));
        }

        private void MenuOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(OrderListControl), 0);
        }

        private void MenuReviewsButton_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(ReviewControl));
        }
    }
}
