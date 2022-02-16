using AutoMapper;
using Fantastic3D.AppModels;
using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fantastic3D.GUI.SectionControls
{
    /// <summary>
    /// Logique d'interaction pour UserListControl.xaml
    /// </summary>
    public partial class UserListControl : UserControl
    {
        public UserList UsersList { get; set; } = new UserList();
        public IDataManager<User, UserDto> _dataSource = ((App)Application.Current).Services.GetService<IDataManager<User, UserDto>>();

        public UserListControl()
        {
            InitializeComponent();
            DataContext = UsersList;
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Navigator.NavigateTo(typeof(UserViewControl));
            ((UserViewControl)((MainWindow)Application.Current.MainWindow).Navigator.CurrentViewControl.Content).CurrentUser = UsersList.CurrentUser;
        }
        // Get All Users and bind them into the listbox
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUsers();
        }

        private void Test()
        {
            //UserRoleComboBox.SelectedItem = UsersList.CurrentUser.Role;
            UserRoleComboBox.SelectedItem = Role.Text;
        }
        private async void LoadUsers()
        {
            try
            { 
                var Users =  await _dataSource.GetAllAsync();
                if (Users != null)
                {
                    UsersList.Users = new ObservableCollection<User>(Users);
                    UserDataGrid.ItemsSource = UsersList.Users;
                }
               // UserRoleComboBox.ItemsSource = Enum.GetValues(typeof(UserRole)).Cast<UserRole>();
                //UserRoleComboBox.SelectedItem = UsersList.Users;
               // UserRoleComboBox.SelectedItem = Role.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Source de données non accessible", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private async void Button_AddUser(object sender, RoutedEventArgs e)
        {
            User userToAdd = new User();
            userToAdd.Username = Username.Text;
            userToAdd.FirstName = FirstName.Text;
            userToAdd.LastName = LastName.Text;
            userToAdd.Email = Email.Text;
            userToAdd.Password = "";
            userToAdd.Role = UserRole.Basic;
            userToAdd.BillingAddress = BillingAddress.Text;

            var totalUsers = UsersList.Users.Count;

            await _dataSource.AddAsync(userToAdd);
            LoadUsers();
            MessageBox.Show("Ajouté avec succès", "ADD", MessageBoxButton.OK, MessageBoxImage.Information);
        //todo: verifier que k'ajout a etait fiat
        }



        private void Button_DeleteUser(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Voulez-vous vraiment supprimer {UsersList.CurrentUser.Username} ?",
                    "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    _dataSource.DeleteAsync(UsersList.CurrentUser.Id);

            }
            catch
            {

            }
            LoadUsers();
        }

        private void Button_EditUser(object sender, RoutedEventArgs e)
        {
            User newUpdat = new User();
            newUpdat.Id = UsersList.CurrentUser.Id;
            newUpdat.Username = Username.Text;
            newUpdat.FirstName = FirstName.Text;
            newUpdat.LastName = LastName.Text;
            newUpdat.Email = Email.Text;
            newUpdat.Password = "";
            newUpdat.Role = UserRole.Basic;
            newUpdat.BillingAddress = BillingAddress.Text;

            if (MessageBox.Show($"Voulez-vous vraiment Editer {UsersList.CurrentUser.Username} ?",
                    "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                _dataSource.UpdateAsync(UsersList.CurrentUser.Id, newUpdat);
        }
    }
}
