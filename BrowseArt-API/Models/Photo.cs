using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrowseArt_API.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public byte[] ImageData { get; set; }
        
        public string Username { get; set; }
    }
}
