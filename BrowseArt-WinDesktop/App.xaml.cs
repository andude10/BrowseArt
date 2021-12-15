using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BrowseArt_WinDesktop.Views;

namespace BrowseArt_WinDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            StartupWindow startupWindow = new StartupWindow();
            startupWindow.Show();
        }
    }
}
