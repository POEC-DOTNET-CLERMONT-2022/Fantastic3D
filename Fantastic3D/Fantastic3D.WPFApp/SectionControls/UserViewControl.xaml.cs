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
    public partial class UserViewControl : UserControl, IContentLoadableById, IContentLoadableWithModel
    {
        public List<User> UserToValidate { get; set; } = new();
        public IDataManager<User, UserDto> _dataSource = ((App)Application.Current).Services.GetService<IDataManager<User, UserDto>>();


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
                    OnContentUpdated();
                }
            }
        }



        public async void LoadContentById(int id)
        {
            try
            { 
                EditableUser = await _dataSource.GetAsync(id);
            }
            catch (DataRetrieveException ex)
            {
                MessageBox.Show(ex.Message, "Utilisateur non trouvé", MessageBoxButton.OK, MessageBoxImage.Error);
                EditableUser = new User();
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
            ((MainWindow)Application.Current.MainWindow).Navigator.NavigateTo(typeof(OrderListControl), EditableUser.Id);
        }

        private void Button_Avis(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Navigator.NavigateTo(typeof(ReviewControl), EditableUser);
        }

        private void Button_Modele(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Navigator.NavigateTo(typeof(ModelListControl), EditableUser);
        }

        private async void Button_Save(object sender, RoutedEventArgs e)
        {
            if (EditableUser.Id == 0)
            {
                try
                {
                    await _dataSource.AddAsync(EditableUser);
                    MessageBox.Show("Ajouté avec succès", "ADD", MessageBoxButton.OK, MessageBoxImage.Information);
                    ((MainWindow)Application.Current.MainWindow).Navigator.NavigateTo(typeof(UserListControl));

                }
                catch (DataRecordException ex)
                {
                    MessageBox.Show(ex.Message, "Erreur lors de l'ajout", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            if (MessageBox.Show($"Voulez-vous vraiment Editer {EditableUser.Username} ?",
                    "Mise à jour (copier collé méchant)", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                await _dataSource.UpdateAsync(EditableUser.Id, EditableUser);
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
            catch (DataRecordException ex)
            {
                MessageBox.Show(ex.ToString(), "Erreur lors de la suppression", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void OnContentUpdated()
        {
            ValidationButton.Content = (EditableUser.Id == 0) ? "Ajouter" : "Sauvegarder";
            DeletionButton.Visibility = (EditableUser.Id == 0) ? Visibility.Hidden : Visibility.Visible;
        }

        public void LoadContentWithModel(IManageable modelInstance)
        {
            if (modelInstance is User user)
                EditableUser = user;
            else
                throw new NavigationException("Expected " + typeof(User).Name + " type. Type sent was: " + modelInstance.GetType().Name);
        }
    }
}

