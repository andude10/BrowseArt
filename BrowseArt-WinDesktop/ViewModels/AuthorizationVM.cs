using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using BrowseArt_API.Repositories;
using BrowseArt_API.Models;
using BrowseArt_WinDesktop.Services;

namespace BrowseArt_WinDesktop.ViewModels
{
    public class AuthorizationVM : BaseViewModel
    {
        private IUsersRepository _usersRepository;
        public AuthorizationVM()
        {
            _usersRepository = new UsersRepository();
            Username = "";
            Password = "";
        }

        private string _username;
        public string Username
        {
            get => _username;
            set => RaisePropertyChanged(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => RaisePropertyChanged(ref _password, value);
        }

        #region Command

        private ICommand _login;
        public ICommand Login
        {
            get
            {
                return _login = new RelayCommand(() =>
                {
                    var hashing = new PasswordHashing();

                    var result = _usersRepository.ObjectExists(new User() { Username = Username, HashedPassword = hashing.Hash(Password) });

                    var loginMessage = new LoginMessage(result, Username);
                    WeakReferenceMessenger.Default.Send(loginMessage);
                });
            }
        }

        #endregion
    }
}
