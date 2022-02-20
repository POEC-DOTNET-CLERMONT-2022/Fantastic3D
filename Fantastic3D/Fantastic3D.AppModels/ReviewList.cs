using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.AppModels
{
    public class ReviewList : ObservableModel
    {
        private ObservableCollection<Review> reviews;

        private Review currentReview;
        public Review CurrentReview
        {
            get { return currentReview; }
            set
            {
                if (currentReview != value)
                {
                    currentReview = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<Review> Reviews
        {
            get { return reviews; }
            set
            {
                if (reviews != value)
                {
                    reviews = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

    }
}
