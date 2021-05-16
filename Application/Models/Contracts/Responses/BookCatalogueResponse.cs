using BookCatalogue.Application.Common;
using System;
using System.Collections.Generic;

namespace BookCatalogue.Application.Dto
{
    public class BookCatalogueResponse: ResponseMessage
    {
        public BookCatalogueDto bookCatalogue { get; set; } = new BookCatalogueDto();

    }
}


