using System;
using MediatR;
using BookCatalogue.Application.Dto;

namespace BookCatalogue.Application.BookRegistration.Commands
{
    public class DeleteBookCatalogueCommand :  IRequest<DeleteBookCatalogueResponse>
    {
        public Guid Id { get; set; }
    }
}
