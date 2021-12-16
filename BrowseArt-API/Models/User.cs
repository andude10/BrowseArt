using System.ComponentModel.DataAnnotations;

namespace BrowseArt_API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
    }
}
