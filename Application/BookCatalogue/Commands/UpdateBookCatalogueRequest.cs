using System;
using MediatR;
using BookCatalogue.Application.Models.Contracts.Requests;
using BookCatalogue.Application.Dto;

namespace BookCatalogue.Application.BookRegistration.Commands
{
    public class UpdateBookCatalogueCommand : UpdateBookCatalogueRequest, IRequest<BookCatalogueResponse>
    {
        public Guid Id { get; set; }
    }
}
