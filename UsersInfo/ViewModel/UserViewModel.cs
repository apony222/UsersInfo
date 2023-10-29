using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UsersInfo.Core;
using UsersInfo.Data;
using UsersInfo.Data.SqlOperations;

namespace UsersInfo.ViewModel
{
    class UserViewModel : INotifyPropertyChanged
    {
        private readonly IDataHelper<User> UserDataHelper;
        private User user;
        private User selectedUser;
        private ObservableCollection<User> users;
        public UserViewModel()
        {
            user = new User();
            users = new ObservableCollection<User>();
            UserDataHelper = new UserEntity();
            LoadData();
        }

        private async void LoadData()
        {
           users.Clear();
           
            foreach(User user in await UserDataHelper.getAllAsync())
            {
                users.Add(user);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
       
      protected virtual void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
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
                    OnPropertyChanged(nameof(user.FullName));
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
                if (user.Email != value)
                {
                    user.Email = value;
                    OnPropertyChanged(nameof(user.Email));
                }
            }
        }

        public string PhoneNumber
        {
            get
            {
                return user.PhoneNumber;
            }
            set
            {
                if (user.PhoneNumber != value)
                {
                    user.PhoneNumber = value;
                    OnPropertyChanged(nameof(user.PhoneNumber));
                }
            }
        }


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
                    selectedUser = value;
                    OnPropertyChanged(nameof(selectedUser));
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
                if (users != value)
                {
                    users = value;
                    OnPropertyChanged(nameof(users));
                }
            }
        }

    }
}
