using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookCatalogue.Domain.Entities;

namespace BookCatalogue.Infrastructure.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(t => t.ISBN)
                  .HasColumnType("varchar")
                  .HasMaxLength(13)
                  .IsRequired();

            builder.Property(t => t.Title)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.PublicationDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasMany(t=>t.Authors).WithOne(e=>e.Book);

        }
    }
}
