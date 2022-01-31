using AutoMapper;
using Fantastic3D.AppModels;
using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;

namespace Fantastic3D.GUI.SectionControls
{
    /// <summary>
    /// Logique d'interaction pour UserListControl.xaml
    /// </summary>
    public partial class UserListControl : UserControl
    {
        public UserList UsersList { get; set; } = new UserList();
        public IDataManager<User, UserDto> _dataSource = new ApiDataManager<User, UserDto>();
        //private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        public UserListControl()
        {
            InitializeComponent();
            DataContext = UsersList;
        }

        // Get All Users and bind them into the listbox
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            { 
                var Users = _dataSource.GetAll();
                if (Users != null)
                {
                    UsersList.Users = new ObservableCollection<User>(Users);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Source de données non accessible", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            LoadUsers();
        }

        private void Button_AddUser(object sender, RoutedEventArgs e)
        {
            UserDto newDto = new UserDto();
            //newDto.Id = 4;
            newDto.FirstName = FirstName.Text;
            newDto.LastName = LastName.Text;
            newDto.Email = Email.Text;
            newDto.Password = "ppppp";
           // newDto.HashSalt = string.Empty;
            //newDto.Role = Role.Text;
            newDto.BillingAddress = BillingAddress.Text;

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7164/");
            client.DefaultRequestHeaders.Accept.Add(
                 new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync("/api/User", newDto).Result;

            if (response.IsSuccessStatusCode)

            {
                MessageBox.Show("Employee Added");
            }

            else

            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase + response.ToString());
            }
        }



        private void Button_DeleteUser(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = 2;

                _dataSource.Delete(id);
                LoadUsers();
            }
            catch
            {

            }
        }

        private void Button_EditUser(object sender, RoutedEventArgs e)
        {

            UserDto newDto = new UserDto();
            //newDto.Id = 4;
            newDto.FirstName = FirstName.Text;
            newDto.LastName = LastName.Text;
            newDto.Email = Email.Text;
            newDto.Password = "ppppp";
            // newDto.HashSalt = string.Empty;
            //newDto.Role = Role.Text;
            newDto.BillingAddress = BillingAddress.Text;

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7164/");
            var id = 2;
            var url = "/api/User/" + id;

            HttpResponseMessage response = client.PutAsJsonAsync(url, newDto).Result;

            if (response.IsSuccessStatusCode)

            {
                MessageBox.Show("User Editer");
                LoadUsers();

                // BindEmployeeList();

            }

            else

            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);

            }
        }
    }
}
