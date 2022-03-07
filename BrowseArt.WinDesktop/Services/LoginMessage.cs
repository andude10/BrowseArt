namespace BrowseArt.WinDesktop.Services;

internal class LoginMessage
{
    public LoginMessage(bool isSuccessful, string currentUsername)
    {
        IsSuccessful = isSuccessful;
        CurrentUsername = currentUsername;
    }

    public bool IsSuccessful { get; set; }
    public string CurrentUsername { get; set; }
}