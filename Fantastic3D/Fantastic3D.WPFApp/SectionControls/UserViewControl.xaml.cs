using Fantastic3D.AppModels;
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
        }
    }
}
