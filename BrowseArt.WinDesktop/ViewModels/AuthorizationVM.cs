using System.Windows.Input;
using BrowseArt.Core.Models;
using BrowseArt.Core.Repositories;
using BrowseArt.WinDesktop.Services;
using BrowseArt.WinDesktop.Utilities;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace BrowseArt.WinDesktop.ViewModels;

public class AuthorizationVM : BaseViewModel
{
    private readonly IUsersRepository _usersRepository;
    private string _password;

    private string _username;

    public AuthorizationVM()
    {
        _usersRepository = new UsersRepository();
        Username = "";
        Password = "";
    }

    public string Username
    {
        get => _username;
        set => RaisePropertyChanged(ref _username, value);
    }

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

                var result = _usersRepository.ObjectExists(new User
                    {Username = Username, HashedPassword = hashing.Hash(Password)});

                var loginMessage = new LoginMessage(result, Username);
                WeakReferenceMessenger.Default.Send(loginMessage);
            });
        }
    }

    #endregion
}