using System.Threading;
using System.Threading.Tasks;
using MediatR;
using BookCatalogue.Application.Services;
using BookCatalogue.Application.Enums;
using BookCatalogue.Application.Command;
using BookCatalogue.Application.Dto;

namespace BookCatalogue.Application.BookRegistration.EventHandlers
{
    public class CreateBookCatalogueCommandHandler : IRequestHandler<CreateBookCatalogueCommand, BookCatalogueResponse>
    {
        private readonly IBookCatelogueService bookCatelogueService;
        private readonly IMesseageQueueService messeageQueueService;

        public CreateBookCatalogueCommandHandler(IBookCatelogueService bookCatelogueService, IMesseageQueueService messeageQueueService)
        {
            this.bookCatelogueService = bookCatelogueService;
            this.messeageQueueService = messeageQueueService;
        }
    
        public async Task<BookCatalogueResponse> Handle(CreateBookCatalogueCommand request, CancellationToken cancellationToken)
        {
            var response = await bookCatelogueService.CreateBookCatalogue(request);

            if(response.Status == Status.Success)
                messeageQueueService.SendMessage("Book Added");

            return response;
        }
    }
}
