using AutoMapper;
using Fantastic3D.AppModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Logique d'interaction pour UserListControl.xaml
    /// </summary>
    public partial class UserListControl : UserControl
    {
        public UserList UsersList { get; set; } = new UserList();

        public Client _client = new Client();

        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        //private readonly DependencyProperty dependencyProperty =
        //    DependencyProperty.Register("CurrentUser", typeof(User), typeof(UserListControl));

        //private User currentUser;
        //public User CurrentUser
        //{
        //    get { return GetValue(dependencyProperty) as User; }
        //    set
        //    {
        //        if (currentUser != value)
        //        {
        //            SetValue(dependencyProperty, value);
        //        }
        //    }
        //}



        public UserListControl()
        {
            InitializeComponent();
            DataContext = UsersList;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var maRequeteAll = await _client.GetAll();

            var Users = _mapper.Map<IEnumerable<User>>(maRequeteAll);

            UsersList.Users = new ObservableCollection<User>(Users);

        }



    }
}
