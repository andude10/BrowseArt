using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BrowseArt_API.Models;
using BrowseArt_API.Repositories;
using BrowseArt_WinDesktop.Services;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace BrowseArt_WinDesktop.ViewModels
{
    public class StartupVM : BaseViewModel
    {
        public StartupVM()
        {
            CurrentContent = new AuthorizationVM();
        }

        private BaseViewModel _currentContent;
        public BaseViewModel CurrentContent
        {
            get => _currentContent;
            set => RaisePropertyChanged(ref _currentContent, value);
        }

        #region Command

        private ICommand _toAuthorizationScreen;
        public ICommand ToAuthorizationScreen
        {
            get
            {
                return _toAuthorizationScreen = new RelayCommand(() =>
                {
                    CurrentContent = new AuthorizationVM();
                });
            }
        }

        private ICommand _toRegistrationScreen;
        public ICommand ToRegistrationScreen
        {
            get
            {
                return _toRegistrationScreen = new RelayCommand(() =>
                {
                    CurrentContent = new RegistrationVM();
                });
            }
        }

        #endregion
    }
}
