namespace BrowseArt_API.Repositories
{
    internal interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetUsersList(); 
        T GetObject(int id); 
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
        void Save();
    }
}
