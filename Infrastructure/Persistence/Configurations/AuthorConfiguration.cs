using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookCatalogue.Domain.Entities;

namespace BookCatalogue.Infrastructure.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(t => t.AuthorName)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(t => t.Book).WithMany(e => e.Authors);
        }
    }
}
