using BrowseArt.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BrowseArt_API.SQL;

internal class DatabaseContext : DbContext
{
    public DbSet<Photo> Photos { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=BrowseArtDB;");
    }
}