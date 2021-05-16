using System;
using System.Threading.Tasks;
using BookCatalogue.Application.BookRegistration.Commands;
using BookCatalogue.Application.BookRegistration.Query;
using BookCatalogue.Application.Command;
using BookCatalogue.Application.Dto;

namespace BookCatalogue.Application.Services
{
    public interface IBookCatelogueService
    {
        bool BookExists(Guid Id);
        SearchCatalogueResponse GetBookCatalogue(Guid Id);
        SearchCatalogueResponse GetBookCatalogues(GetSearchCatalogueQuery searchCriteria);      
        Task<BookCatalogueResponse> CreateBookCatalogue(CreateBookCatalogueCommand bookCatalogueDto);
        Task<BookCatalogueResponse> UpdateBookCatalogue(UpdateBookCatalogueCommand bookCatalogueDto);
        Task<DeleteBookCatalogueResponse> DeleteBookCatalogue(Guid Id);       
    }
}