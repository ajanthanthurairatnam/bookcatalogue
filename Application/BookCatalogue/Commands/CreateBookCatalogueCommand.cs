using System;
using System.Collections.Generic;
using MediatR;
using BookCatalogue.Application.Dto;

namespace BookCatalogue.Application.Command
{
    public class CreateBookCatalogueCommand :IRequest<BookCatalogueResponse>
    {
        public string Title { get; set; }
        public ICollection<AuthorCreateRequest> Authors { get; set; }
          = new List<AuthorCreateRequest>();
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
