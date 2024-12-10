using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class RealDatabase(DbContextOptions<RealDatabase> options) : DbContext(options)
    {
        



        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RAASHID\\SQLEXPRESS;Database=RaashidDemo;Trusted_Connection=true;TrustServerCertificate=true;");
        }
    }
}
