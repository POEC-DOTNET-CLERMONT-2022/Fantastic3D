using Fantastic3D.AppModels;
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
    /// Logique d'interaction pour UserViewControl.xaml
    /// </summary>
    public partial class UserViewControl : UserControl
    {
        public List<User> UserToValidate { get; set; } = new();
        public INavigator Navigator { get; } = new Navigator();

        private static readonly DependencyProperty CurrentUserProperty =
            DependencyProperty.Register("CurrentUser", typeof(User), typeof(UserViewControl));

        private User currentUser;
        public User CurrentUser
        {
            get { return GetValue(CurrentUserProperty) as User; }
            set
            {
                if (currentUser != value)
                {
                    SetValue(CurrentUserProperty, value);
                }
            }
        }
        public UserViewControl()
        {
            InitializeComponent();
            UserToValidate = new List<User>();
            DataContext = UserToValidate;
        }

        private void Button_Commande(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Navigator.NavigateTo(typeof(OrderListControl));
        }

        private void Button_Avis(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Navigator.NavigateTo(typeof(ReviewControl));
        }

        private void Button_Modele(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Navigator.NavigateTo(typeof(ModelListControl)); 
        }
    }
}
