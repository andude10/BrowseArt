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
    public class UsersRepository : IRepository<User>
    {
        ~UsersRepository()
        {
            Dispose();
        }

        private readonly DatabaseContext dbContext = new DatabaseContext();

        public void Create(User user)
        {
            if(dbContext.Users.Any(u => u.Username == user.Username)) return;
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            User? user = dbContext.Users.Find(id);

            if (user != null)
            {
                dbContext.Users.Remove(user);
            }

            dbContext.SaveChanges();
        }

        public IEnumerable<User> GetObjectsList()
        {
            return dbContext.Users;
        }

        public User GetObject(int id)
        {
            return dbContext.Users.Find(id);
        }

        public void Save()
        {
            dbContext.SaveChanges();
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

        private bool disposed;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
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
