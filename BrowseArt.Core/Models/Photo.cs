namespace BrowseArt.Core.Models;

public class Photo
{
    public int PhotoId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public byte[] ImageData { get; set; }

    public string Username { get; set; }
}