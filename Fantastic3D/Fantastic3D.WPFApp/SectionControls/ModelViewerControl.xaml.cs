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
    /// Logique d'interaction pour ModelViewerControl.xaml
    /// </summary>
    public partial class ModelViewerControl : UserControl
    {
        public List<Asset> ModelsToValidate { get; set; } = new();

        private static readonly DependencyProperty CurrentAssetProperty =
            DependencyProperty.Register("CurrentAsset", typeof(Asset), typeof(ModelViewerControl));

        private Asset currentAsset;

        public List<string> LicencesList = new List<string>()
        {
            "Usage commercial", "Usage personnel", "Libre de droit", "MIT"
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
                }
            }
        }

        public IDataManager<Asset, AssetDto> _assetsSource = new ApiDataManager<Asset, AssetDto>();
        public ModelViewerControl()
        {
            InitializeComponent();
            ModelsToValidate = new List<Asset>();
            NextModelsList.ItemsSource = ModelsToValidate;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Faulty endpoints. Tags can't be edited.", "Invalid operation", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _assetsSource.UpdateAsync(CurrentAsset.Id, CurrentAsset);
        }

        private void PublishButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentAsset.Status = Asset.PublicationStatus.Published;
            _assetsSource.UpdateAsync(CurrentAsset.Id, CurrentAsset);
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentAsset.Status = Asset.PublicationStatus.Rejected;
            _assetsSource.UpdateAsync(CurrentAsset.Id, CurrentAsset);
        }
    }
}
