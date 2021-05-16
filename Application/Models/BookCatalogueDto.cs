using System;
using System.Collections.Generic;

namespace BookCatalogue.Application.Dto
{
    public class BookCatalogueDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<AuthorDto> Authors { get; set; }
          = new List<AuthorDto>();
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}


