using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.AppModels
{
    public class UserList : ObservableModel
    {
        private ObservableCollection<User> users;

        private User currentUser;
        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (currentUser != value)
                {
                    currentUser = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                if (users != value)
                {
                    users = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

    }
}
