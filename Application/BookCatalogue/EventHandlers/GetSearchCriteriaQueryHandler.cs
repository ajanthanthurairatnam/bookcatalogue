using System.Threading;
using System.Threading.Tasks;
using MediatR;
using BookCatalogue.Application.BookRegistration.Query;
using BookCatalogue.Application.Dto;
using BookCatalogue.Application.Services;

namespace BookCatalogue.Application.BookRegistration.EventHandlers
{
    public class GetSearchCriteriaQueryHandler : IRequestHandler<GetSearchCatalogueQuery, SearchCatalogueResponse>
    {
        private readonly IBookCatelogueService bookCatelogueService;
        public GetSearchCriteriaQueryHandler(IBookCatelogueService bookCatelogueService)
        {
            this.bookCatelogueService = bookCatelogueService;
        }
        public Task<SearchCatalogueResponse> Handle(GetSearchCatalogueQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(bookCatelogueService.GetBookCatalogues(request));
        }
    }
}
