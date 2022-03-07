using System.Windows;
using System.Windows.Input;
using BrowseArt.Core.Models;
using BrowseArt.Core.Repositories;
using BrowseArt.WinDesktop.Services;
using BrowseArt.WinDesktop.Utilities;
using BrowseArt.WinDesktop.ViewModels;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace BrowseArt_WinDesktop.ViewModels;

public class RegistrationVM : BaseViewModel
{
    private readonly IUsersRepository _usersRepository;
    private string _password;

    private string _repeatedPassword;

    private string _username;

    public RegistrationVM()
    {
        _usersRepository = new UsersRepository();
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
                    MessageBox.Show("Password mismatch", "Registration Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                var hashing = new PasswordHashing();

                if (_usersRepository.IsUsernameNotTaken(Username))
                {
                    _usersRepository.Create(new User {Username = Username, HashedPassword = hashing.Hash(Password)});
                    WeakReferenceMessenger.Default.Send(new LoginMessage(true, Username));
                }
                else
                {
                    MessageBox.Show("Username is taken", "Registration Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            });
        }
    }

    #endregion
}