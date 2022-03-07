using System.Windows.Input;
using BrowseArt_WinDesktop.ViewModels;
using Microsoft.Toolkit.Mvvm.Input;

namespace BrowseArt.WinDesktop.ViewModels;

public class StartupVM : BaseViewModel
{
    private BaseViewModel _currentContent;

    public StartupVM()
    {
        CurrentContent = new AuthorizationVM();
    }

    public BaseViewModel CurrentContent
    {
        get => _currentContent;
        set => RaisePropertyChanged(ref _currentContent, value);
    }

    #region Command

    private ICommand _toAuthorizationScreen;

    public ICommand ToAuthorizationScreen
    {
        get { return _toAuthorizationScreen = new RelayCommand(() => { CurrentContent = new AuthorizationVM(); }); }
    }

    private ICommand _toRegistrationScreen;

    public ICommand ToRegistrationScreen
    {
        get { return _toRegistrationScreen = new RelayCommand(() => { CurrentContent = new RegistrationVM(); }); }
    }

    #endregion
}