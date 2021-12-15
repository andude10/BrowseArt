using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowseArt_WinDesktop.Services
{
    internal class LoginMessage
    {
        public LoginMessage(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }
        public bool IsSuccessful { get; set; }
    }
}
