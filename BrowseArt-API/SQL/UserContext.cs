using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using BrowseArt_API.Models;

namespace BrowseArt_API.SQL
{
    internal class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=BrowseArtDB;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.Property(u => u.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                user.Property(u => u.HashedPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
