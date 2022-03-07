using BrowseArt.Core.Models;
using BrowseArt_API.SQL;
using Microsoft.EntityFrameworkCore;

namespace BrowseArt.Core.Repositories;

public class PhotosRepository : IPhotosRepository
{
    private readonly DatabaseContext _dbContext;

    private bool _disposed;

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
        var photo = _dbContext.Photos.Find(id);

        if (photo != null) _dbContext.Photos.Remove(photo);

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

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _dbContext.Dispose();
        _disposed = true;
    }
}