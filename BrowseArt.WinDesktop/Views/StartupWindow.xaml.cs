using System.Windows;
using BrowseArt.WinDesktop.Services;
using BrowseArt.WinDesktop.ViewModels;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace BrowseArt.WinDesktop.Views;

/// <summary>
///     Interaction logic for StartupWindow.xaml
/// </summary>
public partial class StartupWindow : Window
{
    public StartupWindow()
    {
        InitializeComponent();
        DataContext = new StartupVM();

        WeakReferenceMessenger.Default.Register<StartupWindow, LoginMessage>(this, Login);
    }

    private void Login(StartupWindow recipient, LoginMessage message)
    {
        if (message.IsSuccessful)
        {
            var mainWindow = new MainWindow(message.CurrentUsername);
            mainWindow.Show();
            Close();
        }
        else
        {
            MessageBox.Show("The username or password you entered is incorrect", "Authorization Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}