using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookCatalogue.Domain.Entities;

namespace BookCatalogue.Application
{
    public interface IApplicationDbContext
    {      
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
    }
}
