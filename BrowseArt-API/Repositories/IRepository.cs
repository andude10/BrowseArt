using System;
using System.Collections.Generic;

namespace BrowseArt_API.Repositories
{
    internal interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetObjectsList(); 
        T GetObject(int id); 
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
        void Save();
    }
}
