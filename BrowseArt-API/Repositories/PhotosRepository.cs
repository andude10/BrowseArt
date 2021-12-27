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
    public class PhotosRepository : IPhotosRepository
    {
        private DatabaseContext _dbContext;

        public PhotosRepository()
        {
            _dbContext = new DatabaseContext();
        }

        public void Create(Photo item)
        {
            _dbContext.Photos.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Photo photo = _dbContext.Photos.Find(id);

            if (photo != null)
            {
                _dbContext.Photos.Remove(photo);
            }

            _dbContext.SaveChanges();
        }

        public Photo GetPhoto(int id)
        {
            return _dbContext.Photos.Find(id);
        }

        public void Update(Photo item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        /// <param name="username">Searched user</param>
        /// <returns>Returns a list of all the user's photos</returns>
        public IEnumerable<Photo> GetUserPhotos(string username)
        {
            return _dbContext.Photos.Where(p => p.Username == username);
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
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
