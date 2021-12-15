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

        private ICommand _createUser;
        public ICommand CreateUser
        {
            get
            {
                return _createUser = new RelayCommand(() =>
                {
                    var repository = new UserRepository();
                    repository.Create(new User() {Username = Username, HashedPassword = Password});
                    WeakReferenceMessenger.Default.Send(new LoginMessage(true));
                });
            }
        }

        #endregion
    }
}
