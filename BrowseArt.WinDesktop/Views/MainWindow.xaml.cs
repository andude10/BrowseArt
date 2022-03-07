using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using BrowseArt.WinDesktop.ViewModels;

namespace BrowseArt.WinDesktop.Views;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(string currentUsername)
    {
        InitializeComponent();
        DataContext = new MainVM(currentUsername);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);
    }

    #region TitleBar

    private void CloseWindow(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void MinimizedWindow(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void MaximizedWindow(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Maximized;
    }

    private void MoveWindow(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed) DragMove();
    }

    #endregion
}