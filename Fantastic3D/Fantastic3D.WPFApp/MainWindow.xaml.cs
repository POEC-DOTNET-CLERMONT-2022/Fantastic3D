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
        public MainWindow()
        {
            InitializeComponent();
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

        }

        private void MenuModelButton_Click(object sender, RoutedEventArgs e)
        {

            ShowContent(modelList);
            ShowContent(modelViewer);
        }
    }
}
