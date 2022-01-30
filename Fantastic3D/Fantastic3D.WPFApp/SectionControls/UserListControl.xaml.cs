using AutoMapper;
using Fantastic3D.AppModels;
using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using System;
using System.Collections.ObjectModel;
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
    }
}
