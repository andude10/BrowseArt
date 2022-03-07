using System.Windows;
using BrowseArt.WinDesktop.Views;

namespace BrowseArt.WinDesktop;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var startupWindow = new StartupWindow();
        startupWindow.Show();
    }
}