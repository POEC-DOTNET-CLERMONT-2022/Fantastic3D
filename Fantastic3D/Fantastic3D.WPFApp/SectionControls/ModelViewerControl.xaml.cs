using Fantastic3D.AppModels;
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
        public List<Asset> ModelsToValidate { get; set; }
        public ModelViewerControl()
        {
            InitializeComponent();

            ModelsToValidate = new();

            NextModelsList.ItemsSource = ModelsToValidate;
        }

    }
}
