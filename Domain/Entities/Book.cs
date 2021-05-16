using System;
using System.Collections.Generic;

namespace BookCatalogue.Domain.Entities
{
    public class Book
    {
        public Book()
        {
            
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<Author> Authors { get; set; }
          = new List<Author>();
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
    }


}
