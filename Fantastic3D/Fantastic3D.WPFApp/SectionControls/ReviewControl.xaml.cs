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
    /// Logique d'interaction pour ReviewControl.xaml
    /// </summary>
    public partial class ReviewControl : UserControl, IContentLoadableWithModel
    {
        public ReviewList ReviewsList { get; set; } = new ReviewList();

        public IDataManager<Review, ReviewDto> _dataSource = ((App)Application.Current).Services.GetService<IDataManager<Review, ReviewDto>>();
        private int _filterUserId = 0;
        private int _filterAssetId = 0;

        public ReviewControl()
        {
            InitializeComponent();
            DataContext = ReviewsList;
            
        }
        public void LoadContentWithModel(IManageable modelInstance)
        {
            switch (modelInstance)
            {
                case User u:
                    _filterUserId = u.Id;
                    _filterAssetId = 0;
                    break;

                default:
                    _filterUserId = 0;
                    _filterAssetId = 0;
                    break;
            }

          }


        private async void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if(ReviewsList.CurrentReview.IsPublished == true)
            {
                ReviewsList.CurrentReview.IsPublished = false;
            }
            else
            {
                ReviewsList.CurrentReview.IsPublished = true;
            }
            await _dataSource.UpdateAsync(ReviewsList.CurrentReview.Id, ReviewsList.CurrentReview);
            LoadReviews();
        }
        private void DeleteReview(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Voulez-vous vraiment supprimer {ReviewsList.CurrentReview.AuthorName} ?",
                    "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    _dataSource.DeleteAsync(ReviewsList.CurrentReview.Id);
                LoadReviews();
            }
            catch (DataRecordException ex)
            {
                MessageBox.Show(ex.ToString(), "Erreur lors de la suppression", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadReviews();
        }


        private async void LoadReviews()
        {
            try
            {
                var Reviews = await _dataSource.GetAllAsync();
                if (Reviews != null && Reviews.Any())
                {
                    ReviewsList.Reviews = new ObservableCollection<Review>(Reviews);

                }
                else
                {
                    MessageBox.Show($"Aucune review trouvé. La base de donnée est peut-être vide ou l'API est innaccessible.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Source de données non accessible", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void CollectionViewSource_OnFilter(object sender, FilterEventArgs e)
        {
            var review = e.Item as Review;

            if (review.AuthorId == _filterUserId || _filterUserId == 0)
            {
                e.Accepted = true;
                return;
            }

            e.Accepted = false;
        }

        private void ViewUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Tag != null && ((Button)sender).Tag is int userId)
            {
                ((MainWindow)Application.Current.MainWindow)
                    .Navigator.NavigateTo(typeof(UserViewControl), userId);
            }
        }

        private void ViewAssetButton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Tag != null && ((Button)sender).Tag is int assetId)
            {
                ((MainWindow)Application.Current.MainWindow)
                    .Navigator.NavigateTo(typeof(ModelViewerControl), assetId);
            }
        }


    }
}
