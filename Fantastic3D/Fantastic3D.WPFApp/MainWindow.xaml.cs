using Fantastic3D.GUI.SectionControls;
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
        private ModelViewerControl modelViewer { get; set; } = new();
        private ModelListControl modelList { get; set; } = new();
        private HomeScreenControl homeScreen { get; set; } = new();
        private ReviewControl reviewList { get; set; } = new();
        private UserListControl userList { get; set; } = new();
        private OrderListControl orderList { get; set; } = new();
        public MainWindow()
        {
            InitializeComponent();
            ShowContent(homeScreen);
        }

        public void ShowContent(UserControl userControl)
        {
            MainContent.Content = userControl;
        }

        private void TopMenuControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MenuHomeButton_Click(object sender, RoutedEventArgs e)
        {
            ShowContent(homeScreen);
        }

        private void MenuModelButton_Click(object sender, RoutedEventArgs e)
        {

            ShowContent(modelList);
            //ShowContent(modelViewer);
        }

        private void MenuUsersButton_Click(object sender, RoutedEventArgs e)
        {
            ShowContent(userList);
        }

        private void MenuOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            ShowContent(orderList);

        }

        private void MenuReviewsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowContent(reviewList);

        }
    }
}
