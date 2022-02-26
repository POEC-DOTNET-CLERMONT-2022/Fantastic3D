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
    /// Logique d'interaction pour ModelViewerControl.xaml
    /// </summary>
    public partial class ModelViewerControl : UserControl, IContentLoadableWithModel, IContentLoadableById
    {
        public List<Asset> ModelsToValidate { get; set; } = new();
        private IDataManager<Asset, AssetDto> _dataSource = ((App)Application.Current).Services.GetService<IDataManager<Asset, AssetDto>>();
        private Asset _nextAssetToValidate;

        private static readonly DependencyProperty CurrentAssetProperty =
            DependencyProperty.Register(nameof(CurrentAsset), typeof(Asset), typeof(ModelViewerControl));
        private static readonly DependencyProperty LicencesListProperty =
            DependencyProperty.Register(nameof(LicencesList), typeof(List<string>), typeof(ModelViewerControl));
        private static readonly DependencyProperty FormatsListProperty =
            DependencyProperty.Register(nameof(FormatsList), typeof(List<string>), typeof(ModelViewerControl));

        private Asset currentAsset;

        public List<string> LicencesList = new List<string>()
        {
            "Usage commercial", "Usage personnel", "Libre de droit"
        };
        public List<string> FormatsList = new List<string>()
        {
            "Fbx", "Obj", "3ds", "Max", "X3D", "STL"
        };

        public Asset CurrentAsset
        {
            get { return GetValue(CurrentAssetProperty) as Asset; }
            set
            {
                if (currentAsset != value)
                {
                    SetValue(CurrentAssetProperty, value);
                    OnContentLoaded();
                }
            }
        }

        public IDataManager<Asset, AssetDto> _assetsSource = ((App)Application.Current).Services.GetService<IDataManager<Asset, AssetDto>>();
        public ModelViewerControl()
        {
            InitializeComponent();
        }

        private async void LoadUnpublishedAssetsListAsync()
        {

            ModelsToValidate = (await _dataSource.GetAllAsync()).Where(asset => asset.Status == Asset.PublicationStatus.Unpublished).ToList();
            NextModelsList.ItemsSource = ModelsToValidate;
            if(ModelsToValidate.Count > 1)
            {
                _nextAssetToValidate = ModelsToValidate[1];
                NextButton.IsEnabled = true;
            }
            else
            {
                NextButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Mise à jour de la vue selon la données chargée
        /// </summary>
        private void OnContentLoaded()
        {
            LoadUnpublishedAssetsListAsync();
            PublishButton.IsEnabled = (CurrentAsset.Status == Asset.PublicationStatus.Unpublished);
            RejectButton.IsEnabled = (CurrentAsset.Status == Asset.PublicationStatus.Unpublished);
        }


        public void LoadContentWithModel(IManageable modelInstance)
        {
            if(modelInstance is Asset asset)
            { 
                CurrentAsset = asset;
            }
            else
                throw new NavigationException("Expected " + typeof(Asset).Name + " type. Type sent was: " + modelInstance.GetType().Name);
        }

        public async void LoadContentById(int id)
        {
            try
            {
                CurrentAsset = await _assetsSource.GetAsync(id);
            }
            catch (DataRetrieveException ex)
            {
                MessageBox.Show(ex.Message, "Modèle 3D non trouvé", MessageBoxButton.OK, MessageBoxImage.Error);
                CurrentAsset = new();
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Faulty endpoints. Tags can't be edited.", "Invalid operation", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveButton.IsEnabled = false;
            _assetsSource.UpdateAsync(CurrentAsset.Id, CurrentAsset);
        }

        private void PublishButton_Click(object sender, RoutedEventArgs e)
        {
            PublishButton.IsEnabled = false;
            RejectButton.IsEnabled = false;
            CurrentAsset.Status = Asset.PublicationStatus.Published;
            _assetsSource.UpdateAsync(CurrentAsset.Id, CurrentAsset);
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            SaveButton.IsEnabled = false;
            PublishButton.IsEnabled = false;
            RejectButton.IsEnabled = false;
            CurrentAsset.Status = Asset.PublicationStatus.Rejected;
            _assetsSource.UpdateAsync(CurrentAsset.Id, CurrentAsset);
        }

        private void CheckUserButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow)
                .Navigator.NavigateTo(typeof(UserViewControl), CurrentAsset.CreatorId);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow)
                .Navigator.NavigateTo(typeof(ModelViewerControl), _nextAssetToValidate);
        }
    }
}
