using BookShelf.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>().HasData(
        //        new Category() {Id=1, Name = "English Classics", DisplayOrder = 1 },
        //        new Category() {Id=2, Name = "Tamil Classics", DisplayOrder = 2 });;
        //}
    }
}
