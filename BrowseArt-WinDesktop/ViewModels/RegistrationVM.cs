using System.Windows;
using System.Windows.Input;
using BrowseArt_API.Models;
using BrowseArt_API.Repositories;
using BrowseArt_WinDesktop.Services;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace BrowseArt_WinDesktop.ViewModels
{
    public class RegistrationVM : BaseViewModel
    {
        private IUsersRepository _usersRepository;

        public RegistrationVM()
        {
            _usersRepository = new UsersRepository();
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

        private string _repeatedPassword;
        public string RepeatedPassword
        {
            get => _repeatedPassword;
            set => RaisePropertyChanged(ref _repeatedPassword, value);
        }

        #region Command

        private ICommand _createUser;
        public ICommand CreateUser
        {
            get
            {
                return _createUser = new RelayCommand(() =>
                {
                    if (Password != RepeatedPassword)
                    {
                        MessageBox.Show("Password mismatch", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    var hashing = new PasswordHashing();

                    if (_usersRepository.IsUsernameNotTaken(Username))
                    {
                        _usersRepository.Create(new User() {Username = Username, HashedPassword = hashing.Hash(Password)});
                        WeakReferenceMessenger.Default.Send(new LoginMessage(true, Username));
                    }
                    else
                    {
                        MessageBox.Show("Username is taken", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                });
            }
        }

        #endregion
    }
}
