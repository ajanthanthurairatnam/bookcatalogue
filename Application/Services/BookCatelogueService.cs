using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookCatalogue.Application.BookRegistration.Commands;
using BookCatalogue.Application.BookRegistration.Query;
using BookCatalogue.Application.Command;
using BookCatalogue.Application.Dto;
using BookCatalogue.Application.Enums;
using BookCatalogue.Domain.Entities;

namespace BookCatalogue.Application.Services
{
    public class BookCatelogueService : IBookCatelogueService
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        public BookCatelogueService(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext ?? throw new ArgumentNullException();
            this.mapper = mapper ?? throw new ArgumentNullException();
        }

        public bool BookExists(Guid Id)
        {
            return applicationDbContext.Books.Any(e => e.Id == Id);
        }

        public SearchCatalogueResponse GetBookCatalogue(Guid Id)
        {
            var response = new SearchCatalogueResponse();
            var books = applicationDbContext.Books.Where(e => e.Id == Id);

            if (books.Any())
            {
                var bookCatalogues = mapper.Map<IEnumerable<BookCatalogueDto>>(books);
                response.bookCatalogues = bookCatalogues;
            }

            response.Status = books != null ? Status.Success : Status.NotFound;
            return response;
        }

        public SearchCatalogueResponse GetBookCatalogues(GetSearchCatalogueQuery searchCriteria)
        {
            var response = new SearchCatalogueResponse();
            Func<Book, bool> filter = (e) => (
                                    (!searchCriteria.Id.HasValue || e.Id == searchCriteria.Id) &&
                                    (searchCriteria.Title == string.Empty || e.Title.Contains(searchCriteria.Title)) &&
                                    (searchCriteria.ISBN == string.Empty || e.ISBN.Contains(searchCriteria.ISBN)) &&
                                    (searchCriteria.Author == string.Empty || e.Authors.Any(a => a.AuthorName.Contains(searchCriteria.Author)))
                                            );
            var books = applicationDbContext.Books.Include(e => e.Authors).Where(filter);

            var bookCatalogues = mapper.Map<IEnumerable<BookCatalogueDto>>(books);
            response.Status = Status.Success;
            response.bookCatalogues = bookCatalogues;
            return response;
        }


        public async Task<BookCatalogueResponse> CreateBookCatalogue(CreateBookCatalogueCommand CreateBookCatalogueRequest)
        {          
            var book = mapper.Map<Book>(CreateBookCatalogueRequest);
            await applicationDbContext.Books.AddAsync(book);
            await applicationDbContext.SaveChangesAsync();

            var response = mapper.Map<BookCatalogueResponse>(book);
            response.Status = Status.Success;
            response.bookCatalogue.Id = book.Id;
            return response;
        }

        public async Task<BookCatalogueResponse> UpdateBookCatalogue(UpdateBookCatalogueCommand bookCatalogueDto)
        {
            var bookRequest = mapper.Map<Book>(bookCatalogueDto);

            var book = applicationDbContext.Books.Include(e => e.Authors).Where(e => e.Id == bookCatalogueDto.Id).FirstOrDefault();  
            if (book is null)
                return new BookCatalogueResponse() { Status = Status.NotFound, Message ="Book Catelogue Not Found." };           

            book.PublicationDate = bookRequest.PublicationDate == null ? book.PublicationDate : bookRequest.PublicationDate;
            book.Title = string.IsNullOrEmpty(bookRequest.Title) ? book.Title  : bookRequest.Title ;
            book.ISBN = string.IsNullOrEmpty(bookRequest.ISBN) ? book.ISBN : bookRequest.ISBN;

            var currentAuthors = book.Authors;
            var bookRequestAuthors = bookRequest.Authors.Select(e => e.Id);
            var removeableAuthorIDs = currentAuthors.Where(r => !bookRequestAuthors.Contains(r.Id));
            applicationDbContext.Authors.RemoveRange(removeableAuthorIDs);

            book.Authors = bookRequest.Authors;
            foreach (var author in book.Authors)
                author.Book = book;
            await applicationDbContext.SaveChangesAsync();

            var response = mapper.Map<BookCatalogueResponse>(book);
            response.Status = Status.Success;
            return response;
        }

        public async Task<DeleteBookCatalogueResponse> DeleteBookCatalogue(Guid Id)
        {
            var book = applicationDbContext.Books.Where(e => e.Id ==  Id);
            
            if (book is null)
                return new DeleteBookCatalogueResponse() { Status = Status.NotFound, Message = "Book catalogue not found." };

                var authors = applicationDbContext.Authors.Where(e => e.Book.Id == Id);

                applicationDbContext.Authors.RemoveRange(authors);
                applicationDbContext.Books.RemoveRange(book);

                await applicationDbContext.SaveChangesAsync();

            return new DeleteBookCatalogueResponse() { Status = Status.Success , Message = "Book catalogue deleted." };
        }

    }
    
}
