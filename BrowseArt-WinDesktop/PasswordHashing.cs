using System;
using System.Security.Cryptography;
using System.Text;

namespace BrowseArt_WinDesktop
{
    internal class PasswordHashing
    {
        public string Hash(string password)
        {
            var data = Encoding.Default.GetBytes(password);
            SHA1 sha = SHA1.Create();
            var result = sha.ComputeHash(data);
            password = Convert.ToBase64String(result);
            return password;
        }
    }
}
