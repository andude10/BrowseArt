using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowseArt_API.Models;
using BrowseArt_API.SQL;
using Microsoft.EntityFrameworkCore;

namespace BrowseArt_API.Repositories
{
    //TODO: Make asynchronous database access
    public class UserRepository : IRepository<User>
    {
        ~UserRepository()
        {
            Dispose();
        }

        private UserContext db = new UserContext();
        public void Create(User item)
        {
            db.Users.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);

            if (user != null)
            {
                db.Users.Remove(user);
            }

            db.SaveChanges();
        }

        public IEnumerable<User> GetUsersList()
        {
            return db.Users;
        }

        public User GetObject(int id)
        {
            return db.Users.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// This method determines if a user exists with the same password and username.
        /// Compares hashed passwords.
        /// </summary>
        /// <param name="user">Searched user</param>
        private async Task<bool> ObjectExistsAsync(User user)
        {
            return await db.Users.AnyAsync(u => u.Username == user.Username &&
                                                    u.HashedPassword == user.HashedPassword);
        }

        /// <summary>
        /// This method determines if a user exists with the same password and username.
        /// Compares hashed passwords.
        /// </summary>
        /// <param name="user">Searched user</param>
        public bool ObjectExists(User user)
        {
            return db.Users.Any(u => u.Username == user.Username && 
                                         u.HashedPassword == user.HashedPassword);
        }

        private bool disposed;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
