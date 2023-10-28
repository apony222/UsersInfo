using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UsersInfo.Core;

namespace UsersInfo.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        #region Fields
        private User user;
        private User selectedUser;
        private ObservableCollection<User> users;
        #endregion

       
        public UserViewModel() 
        {
         user = new User();
         users = new ObservableCollection<User>();
        }


        #region Properties
        public string FullName 
        {
            get
            { 
            return user.FullName;
            }

            set 
            {
                if(user.FullName!=value)
                { 
                    user.FullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public string Email
        {
            get
            {
                return user.Email;
            }
            set
            {
                if(user.Email!=value)
                {
                    user.Email = value;
                    OnPropertyChanged(nameof(Email));
                }
            } 
        }

        public string PhoneNumber 
        {
            get 
            {
            return (string)user.PhoneNumber;
            }

            set
            {
                if(user.PhoneNumber!=value) 
                {
                    if(user.PhoneNumber!=value)
                    {
                        user.PhoneNumber = value;
                        OnPropertyChanged(nameof(PhoneNumber));
                    }
                }
            }
        }
        #endregion


        public User SelectedUser 
        {
            get 
            {
                return selectedUser;
            }
            set 
            {
                if (selectedUser != value)
                {
                    selectedUser=value;
                    OnPropertyChanged(nameof(SelectedUser));
                }
            } 
        }

        public ObservableCollection<User> Users
        {
            get 
            {
                return users; 
            }
            set 
            {
                if (users!=value)
                {
                    users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
