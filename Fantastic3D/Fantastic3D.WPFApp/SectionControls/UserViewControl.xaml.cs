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
    /// Logique d'interaction pour UserViewControl.xaml
    /// </summary>
    public partial class UserViewControl : UserControl
    {
        public List<User> UserToValidate { get; set; } = new();
        public IDataManager<User, UserDto> _dataSource = ((App)Application.Current).Services.GetService<IDataManager<User, UserDto>>();
        public INavigator Navigator { get; } = new Navigator();

        private static readonly DependencyProperty CurrentUserProperty =
            DependencyProperty.Register(nameof(EditableUser), typeof(User), typeof(UserViewControl));

        private User editableUser;
        public User EditableUser
        {
            get { return GetValue(CurrentUserProperty) as User; }
            set
            {
                if (editableUser != value)
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

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Voulez-vous vraiment Editer {EditableUser.Username} ?",
                    "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                _dataSource.UpdateAsync(EditableUser.Id, EditableUser);
            ((MainWindow)Application.Current.MainWindow).Navigator.NavigateTo(typeof(UserListControl));
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Voulez-vous vraiment supprimer {EditableUser.Username} ?",
                    "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    _dataSource.DeleteAsync(EditableUser.Id);
                ((MainWindow)Application.Current.MainWindow).Navigator.NavigateTo(typeof(UserListControl));
            }
            catch
            {

            }
            
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                User newUser = new User();
                newUser.Username = Username.Text;
                newUser.FirstName = FirstName.Text;
                newUser.LastName = LastName.Text;
                newUser.Email = Email.Text;
                newUser.Password = Password.Text;
                newUser.Role = UserRole.Basic; // ComboBoxRole.SelectedItem;
                newUser.BillingAddress = Address.Text;

                if (MessageBox.Show($"Voulez-vous vraiment Ajouter {newUser.Username} ?",
                    "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    _dataSource.AddAsync(newUser);
                ((MainWindow)Application.Current.MainWindow).Navigator.NavigateTo(typeof(UserListControl));
            }
            catch
            {

            }
        }
    }
}

