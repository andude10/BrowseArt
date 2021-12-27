using BrowseArt_API.Models;

namespace BrowseArt_API.Repositories
{
    public interface IPhotosRepository : IDisposable
    {
        Photo GetPhoto(int id); 
        void Create(Photo item); 
        void Update(Photo item); 
        void Delete(int id); 
        /// <param name="user">Searched user</param>
        /// <returns>Returns a list of all the user's photos</returns>
        IEnumerable<Photo> GetUserPhotos(string username);
    }
}