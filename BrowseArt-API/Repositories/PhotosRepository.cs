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
    public class PhotosRepository : IRepository<Photo>
    {
        ~PhotosRepository()
        {
            Dispose();
        }

        private DatabaseContext dbContext = new DatabaseContext();

        public void Create(Photo item)
        {
            dbContext.Photos.Add(item);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Photo photo = dbContext.Photos.Find(id);

            if (photo != null)
            {
                dbContext.Photos.Remove(photo);
            }

            dbContext.SaveChanges();
        }


        public Photo GetObject(int id)
        {
            return dbContext.Photos.Find(id);
        }

        public void Update(Photo item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        /// <param name="user">Searched user</param>
        /// <returns>Returns a list of all the user's photos</returns>
        public IEnumerable<Photo> GetUserPhotos(string username)
        {
            return dbContext.Photos.Where(p => p.Username == username);
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
