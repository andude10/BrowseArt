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
        public LoginMessage(bool isSuccessful, User currentUser)
        {
            IsSuccessful = isSuccessful;
            CurrentUser = currentUser;
        }
        public bool IsSuccessful { get; set; }
        public User CurrentUser { get; set; }
    }
}
