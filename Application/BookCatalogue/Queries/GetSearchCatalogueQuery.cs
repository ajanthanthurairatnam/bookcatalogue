using System;
using MediatR;
using BookCatalogue.Application.Dto;

namespace BookCatalogue.Application.BookRegistration.Query
{
    public class GetSearchCatalogueQuery : SearchCatalogueQuery, IRequest<SearchCatalogueResponse>
    {
        public Guid? Id { get; set; } = null;
    }

}
