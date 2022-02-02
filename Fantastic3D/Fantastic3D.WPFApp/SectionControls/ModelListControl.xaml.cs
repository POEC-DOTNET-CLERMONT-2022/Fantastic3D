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
    /// Logique d'interaction pour ModelListControl.xaml
    /// </summary>
    public partial class ModelListControl : UserControl
    {
        public ObservableList<Asset> AssetsList { get; set; } = new ObservableList<Asset>();
        public IDataManager<Asset, AssetDto> _dataSource = new ApiDataManager<Asset, AssetDto>();
        public ModelListControl()
        {
            InitializeComponent();
            DataContext = AssetsList;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAssets();
        }

        private async void LoadAssets()
        {
            try
            {
                var Assets = await _dataSource.GetAllAsync();
                if (Assets != null)
                {
                    AssetsList.Items = new ObservableCollection<Asset>(Assets);
                }
                if()
                MessageBox.Show($"{Assets.Count()} modèles 3D trouvés.", "Connexion réussie", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Source de données non accessible", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
