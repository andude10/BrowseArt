using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowseArt_API.Models;

namespace BrowseArt_WinDesktop.Services
{
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
}
