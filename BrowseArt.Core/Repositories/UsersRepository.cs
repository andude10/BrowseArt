using BrowseArt.Core.Models;
using BrowseArt_API.SQL;
using Microsoft.EntityFrameworkCore;

namespace BrowseArt.Core.Repositories;

//TODO: Make asynchronous database access
public class UsersRepository : IUsersRepository
{
    private readonly DatabaseContext dbContext = new();

    private bool disposed;

    public void Create(User user)
    {
        if (dbContext.Users.Any(u => u.Username == user.Username)) return;
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = dbContext.Users.Find(id);

        if (user != null) dbContext.Users.Remove(user);

        dbContext.SaveChanges();
    }

    public User GetUser(int id)
    {
        return dbContext.Users.Find(id);
    }

    public void Update(User item)
    {
        dbContext.Entry(item).State = EntityState.Modified;
        dbContext.SaveChanges();
    }

    /// <summary>
    ///     This method determines if a user exists with the same password and username.
    ///     Compares hashed passwords.
    /// </summary>
    /// <param name="user">Searched user</param>
    public bool ObjectExists(User user)
    {
        return dbContext.Users.Any(u => u.Username == user.Username &&
                                        u.HashedPassword == user.HashedPassword);
    }

    /// <summary>
    ///     This method determines if the username is taken.
    ///     True if is not taken.
    /// </summary>
    /// <param name="username">Searched username</param>
    public bool IsUsernameNotTaken(string username)
    {
        return !dbContext.Users.Any(u => u.Username == username);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public virtual void Dispose(bool disposing)
    {
        if (!disposed)
            if (disposing)
                dbContext.Dispose();
        disposed = true;
    }
}