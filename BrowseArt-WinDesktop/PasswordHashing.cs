using System;
using System.Security.Cryptography;
using System.Text;

namespace BrowseArt_WinDesktop
{
    internal class PasswordHashing
    {
        public string Hash(string password)
        {
            byte[] data = Encoding.Default.GetBytes(password);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(data);
            password = Convert.ToBase64String(result);
            return password;
        }
    }
}
