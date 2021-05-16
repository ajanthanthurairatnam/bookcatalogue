using BookCatalogue.Application.Common;
using System;
using System.Collections.Generic;

namespace BookCatalogue.Application.Dto
{
    public class SearchCatalogueResponse : ResponseMessage
    {
        public IEnumerable<BookCatalogueDto> bookCatalogues { get; set; } = new List<BookCatalogueDto>();

    }
}


