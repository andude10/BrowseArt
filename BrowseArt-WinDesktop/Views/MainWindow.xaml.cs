using System.ComponentModel;
using System.Windows;
using BrowseArt_API.Models;
using BrowseArt_WinDesktop.ViewModels;

namespace BrowseArt_WinDesktop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(User currentUser)
        {
            InitializeComponent();
            DataContext = new MainVM(currentUser);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private void CloseWindow(object sender, System.Windows.RoutedEventArgs e) => this.Close();
        private void MinimizedWindow(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void MaximizedWindow(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;

        }
        private void MoveWindow(object sender, System.Windows.RoutedEventArgs e)
        {
            DragMove();
        }
    }
}
