using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BrowseArt_API.Models;
using BrowseArt_API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm;
using Microsoft.Toolkit.Mvvm.Input;

namespace BrowseArt_WinDesktop.ViewModels
{
    public class MainVM : BaseViewModel
    {
        public MainVM()
        {
            UserRepository repository = new UserRepository();
            DisplayUsers = new ObservableCollection<User>(repository.GetUsersList());
        }
        private ObservableCollection<User> _displayUsers;
        public ObservableCollection<User> DisplayUsers
        {
            get => _displayUsers;
            set => RaisePropertyChanged(ref _displayUsers, value);
        }

        #region Commands

        private ICommand _createUser;
        public ICommand CreateUser
        {
            get
            {
                return _createUser = new RelayCommand(() =>
                {
                    UserRepository repository = new UserRepository();
                    repository.Create(new User() { Username = "TestUser", HashedPassword = "12345"});
                    UpdateData();
                });
            }
        }

        #endregion

        private void UpdateData()
        {
            UserRepository repository = new UserRepository();
            DisplayUsers = new ObservableCollection<User>(repository.GetUsersList());
        }
    }
}
