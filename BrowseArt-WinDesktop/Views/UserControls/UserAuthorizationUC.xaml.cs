using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BrowseArt_WinDesktop.ViewModels;

namespace BrowseArt_WinDesktop.Views.UserControls
{
    /// <summary>
    /// Interaction logic for UserAuthorizationUC.xaml
    /// </summary>
    public partial class UserAuthorizationUC : UserControl
    {
        public UserAuthorizationUC()
        {
            InitializeComponent();
            DataContext = new AuthorizationVM();
        }
    }
}
