using BrowseArt_API.Models;
using BrowseArt_API.Repositories;
using BrowseArt_API.SQL;

namespace BrowseArt_API
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.Create(new User() { Username = "Sasha", HashedPassword = "test1" });
            userRepository.Create(new User() { Username = "Katia", HashedPassword = "test2" });
            Console.WriteLine("Объекты успешно сохранены");

            var users = userRepository.GetUsersList();
            Console.WriteLine("Список объектов:");
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Username} - {u.HashedPassword}");
            }
        }
    }
}