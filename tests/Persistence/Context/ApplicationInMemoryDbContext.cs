using Microsoft.EntityFrameworkCore;
using BookCatalogue.Infrastructure;

namespace BookCatalogue.Tests.Database
{
    public class ApplicationInMemoryDbContext : ApplicationDbContext
    {
        public ApplicationInMemoryDbContext(DbContextOptions options) : base(options)
        {
           
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            this.Books.AddRange(DbContextSetup.Books);
            this.SaveChanges();
        }
    }
}
