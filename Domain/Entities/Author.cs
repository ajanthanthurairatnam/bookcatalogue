using System;

namespace BookCatalogue.Domain.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; }
        public Book Book { get; set; }
    }
}
