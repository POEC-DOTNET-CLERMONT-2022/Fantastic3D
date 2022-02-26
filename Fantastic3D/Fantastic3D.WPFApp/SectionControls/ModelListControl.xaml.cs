using Fantastic3D.AppModels;
using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using Fantastic3D.GUI.Utilities;
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
    public partial class ModelListControl : UserControl, IContentLoadableWithModel
    {
        public ObservableList<Asset> AssetsList { get; set; } = new ObservableList<Asset>();
        //public Asset SelectedAsset { get; set; }
        public IDataManager<Asset, AssetDto> _dataSource = ((App)Application.Current).Services.GetService<IDataManager<Asset, AssetDto>>();

        private int _filterUserId = 0;
        private bool _publicationFilterActive = false;
        private Asset.PublicationStatus _filterStatus;

        bool messageBoxHasBeenShown = false;
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
                if (Assets != null && Assets.Any())
                {
                    AssetsList.Items = new ObservableCollection<Asset>(Assets);
                    if(messageBoxHasBeenShown)
                    { 
                        MessageBox.Show($"{Assets.Count()} modèles 3D trouvés.", "Connexion réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                        messageBoxHasBeenShown = true;
                    }
                }
                else
                {
                    MessageBox.Show($"Aucun modèle 3D trouvé. La base de donnée est peut-être vide ou l'API est innaccessible.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Source de données non accessible", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(AssetsList.CurrentItem.Name);
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            ((MainWindow)Application.Current.MainWindow)
                .Navigator.NavigateTo(typeof(ModelViewerControl), (Asset)AssetDataGrid.CurrentItem);
        }


        public void ModelListViewSource_OnFilter(object sender, FilterEventArgs e)
        {
            var asset = e.Item as Asset;

            e.Accepted = (_filterUserId == 0 || asset.CreatorId == _filterUserId)
                && (!_publicationFilterActive || asset.Status == _filterStatus);

        }


        public void LoadContentWithModel(IManageable modelInstance)
        {
            if(modelInstance == null)
            {
                _filterUserId = 0;
                _publicationFilterActive = false;
                return;
            }

            if(modelInstance is User user)
            {
                _filterUserId = user.Id;
            }
            else
            {
                throw new NavigationException("This view can't be filtered through something else than an User.");
            }
        }

        private void PublicationFilter_Selected(object sender, RoutedEventArgs e)
        {
            _publicationFilterActive = !(PublicationFilter.SelectedIndex == 0);
            _filterStatus = PublicationFilter.SelectionBoxItem switch
            {
                "Publiés" => Asset.PublicationStatus.Published,
                "Refusés" => Asset.PublicationStatus.Rejected,
                "Effacés" => Asset.PublicationStatus.Removed,
                _ => Asset.PublicationStatus.Unpublished,
            };

            _filterUserId = 0;
            AssetDataGrid.Items.Refresh();
        }
    }
}
