using System.Windows.Controls;
using BrowseArt.WinDesktop.ViewModels;

namespace BrowseArt.WinDesktop.Views.UserControls;

/// <summary>
///     Interaction logic for UserAuthorizationUC.xaml
/// </summary>
public partial class UserAuthorizationUC : UserControl
{
    public UserAuthorizationUC()
    {
        InitializeComponent();
        DataContext = new AuthorizationVM();
    }
}