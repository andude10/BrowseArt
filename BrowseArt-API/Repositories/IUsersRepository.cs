using BrowseArt_API.Models;

namespace BrowseArt_API.Repositories
{
    public interface IUsersRepository : IDisposable
    {
        void Create(User user);
        void Delete(int id);
        User GetUser(int id);
        void Update(User item);
        bool ObjectExists(User user);
        bool IsUsernameNotTaken(string username);
    }
}