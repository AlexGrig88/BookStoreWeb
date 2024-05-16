using BookStoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Художественная литература", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Детские книги", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Наука. Техника. IT", DisplayOrder = 3 }
                );
        }

    }
}
