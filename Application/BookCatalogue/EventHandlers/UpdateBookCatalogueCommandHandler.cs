using System.Threading;
using System.Threading.Tasks;
using MediatR;
using BookCatalogue.Application.BookRegistration.Commands;
using BookCatalogue.Application.Dto;
using BookCatalogue.Application.Enums;
using BookCatalogue.Application.Services;

namespace BookCatalogue.Application.BookRegistration.EventHandlers
{
    public class UpdateBookCatalogueCommandHandler : IRequestHandler<UpdateBookCatalogueCommand, BookCatalogueResponse>
    {
        private readonly IBookCatelogueService bookCatelogueService;
        private readonly IMesseageQueueService messeageQueueService;

        public UpdateBookCatalogueCommandHandler(IBookCatelogueService bookCatelogueService, IMesseageQueueService messeageQueueService)
        {
            this.bookCatelogueService = bookCatelogueService;
            this.messeageQueueService = messeageQueueService;
        }

        public async Task<BookCatalogueResponse> Handle(UpdateBookCatalogueCommand request, CancellationToken cancellationToken)
        {
            var response = await bookCatelogueService.UpdateBookCatalogue(request);

            if (response.Status == Status.Success)
                messeageQueueService.SendMessage("Book Updated");

            return response;

        }
    }
}
