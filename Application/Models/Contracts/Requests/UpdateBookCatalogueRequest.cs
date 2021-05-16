using BookCatalogue.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookCatalogue.Application.Models.Contracts.Requests
{
    public class UpdateBookCatalogueRequest
    {
        public string Title { get; set; }
        public ICollection<AuthorDto> Authors { get; set; }
          = new List<AuthorDto>();
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
