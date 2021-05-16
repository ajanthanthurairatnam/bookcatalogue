using System.Linq;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using BookCatalogue.Application.BookRegistration.Commands;
using BookCatalogue.Application.BookRegistration.Query;
using BookCatalogue.Application.Command;
using BookCatalogue.Application.Dto;
using BookCatalogue.Application.Enums;
using BookCatalogue.Application.Services;
using BookCatalogue.Tests.Persistence;
using BookCatalogue.Tests.Database;

namespace BookCatalogue.Tests
{
    public class BookCatelogueServiceTest
    {
        readonly IBookCatelogueService sut;
        readonly IMapper mapper;

        public BookCatelogueServiceTest(IBookCatelogueService bookCatelogueService, IMapper mapper)
        {
            this.sut = bookCatelogueService;
            this.mapper = mapper;
        }

        [Theory]
        [ClassData(typeof(CreateBookCatelogData))]
        public async Task Create_BookCatalogue_ReturnsCreatedStatus(Status expected, CreateBookCatalogueCommand createBookCatalogueCommand)
        {

            var response = await sut.CreateBookCatalogue(createBookCatalogueCommand);
            Assert.Equal(expected, response.Status);
        }

        [Theory]
        [ClassData(typeof(UpdateBookCatelogData))]
        public async Task Update_BookCatalogue_ReturnsCreatedStatus(Status expected, UpdateBookCatalogueCommand bookcatelog)
        {
            var response = await sut.UpdateBookCatalogue(bookcatelog);
            var bookCatelog = sut.GetBookCatalogue(bookcatelog.Id);
            Assert.True(response.Status == expected && bookCatelog.bookCatalogues.FirstOrDefault().ISBN== bookcatelog.ISBN);
        }

        [Theory]
        [ClassData(typeof(GetSearchCatalogueQueryData))]
        public void Get_SearchCatalogue_QueryData(SearchCatalogueResponse expected, GetSearchCatalogueQuery getSearchCatalogueQuery)
        {
            var response =  sut.GetBookCatalogues(getSearchCatalogueQuery);
            Assert.Equal(expected.Status, response.Status);
        }

        [Fact]
        public void Get_BookCatalogueById_ReturnsSuccessWithResponse()
        {
            var response =  sut.GetBookCatalogue(DbContextSetup.BookIdSample2Id);
            Assert.True(response.Status == Status.Success && response.bookCatalogues.FirstOrDefault().Id  == DbContextSetup.BookIdSample2Id);
        }

        [Fact]
        public void Verify_BookCatalogueExists_ReturnExistance()
        {
            var response = sut.BookExists(DbContextSetup.BookIdSample2Id);
            Assert.True(response); 
        }

        [Fact]
        public async Task Verify_RemoveBookCatalogue_ReturnExistance()
        {
            var existing = sut.BookExists(DbContextSetup.BookIdSample3Id);
            var response = await sut.DeleteBookCatalogue(DbContextSetup.BookIdSample3Id);
            var deleted = !(sut.BookExists(DbContextSetup.BookIdSample3Id));
            Assert.True(existing && response.Status == Status.Success && deleted);
        }
    }
}
