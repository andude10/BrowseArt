using BrowseArt.Core.Models;

namespace BrowseArt.Core.Repositories;

public interface IUsersRepository : IDisposable
{
    void Create(User user);
    void Delete(int id);
    User GetUser(int id);
    void Update(User item);
    bool ObjectExists(User user);
    bool IsUsernameNotTaken(string username);
}