using Fantastic3D.Export;
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

namespace ExternalDataReader.WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new AssetServiceClient();
                RequestOutput.Text = (await client.SearchAssetDtoAsync(UserInput.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Modèle non trouvé.");
            }
        }

        private async void ListButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new AssetServiceClient();
                RequestOutput.Text = String.Join(Environment.NewLine, await client.GetListAsync(0));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connexion dysfonctionnelle ou base vide.");
            }
        }
    }
}
