﻿using Fantastic3D.AppModels;
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
    /// Logique d'interaction pour ReviewControl.xaml
    /// </summary>
    public partial class ReviewControl : UserControl
    {
        public ObservableList<Review> ReviewsList { get; set; } = new ObservableList<Review>();

        public IDataManager<Review, ReviewDto> _dataSource = ((App)Application.Current).Services.GetService<IDataManager<Review, ReviewDto>>();

        public ReviewControl()
        {
            InitializeComponent();
            DataContext = ReviewsList;

        }

        private void DeleteReview(object sender, RoutedEventArgs e)
        {
            LoadReviews();
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
                    ReviewsList.Items = new ObservableCollection<Review>(Reviews);

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
    }
}
