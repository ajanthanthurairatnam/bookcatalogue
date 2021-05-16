using System.Threading;
using System.Threading.Tasks;
using MediatR;
using BookCatalogue.Application.Services;
using BookCatalogue.Application.BookRegistration.Commands;
using BookCatalogue.Application.Enums;
using BookCatalogue.Application.Dto;

namespace BookCatalogue.Application.BookRegistration.EventHandlers
{
    public class DeleteBookCatalogueCommandHandler : IRequestHandler<DeleteBookCatalogueCommand, DeleteBookCatalogueResponse>
    {
        private readonly IBookCatelogueService bookCatelogueService;
        private readonly IMesseageQueueService messeageQueueService;

        public DeleteBookCatalogueCommandHandler(IBookCatelogueService bookCatelogueService, IMesseageQueueService messeageQueueService)
        {
            this.bookCatelogueService = bookCatelogueService;
            this.messeageQueueService = messeageQueueService;
        }
    
        public async Task<DeleteBookCatalogueResponse> Handle(DeleteBookCatalogueCommand request, CancellationToken cancellationToken)
        {
            var response = await bookCatelogueService.DeleteBookCatalogue(request.Id);

            if(response.Status == Status.Success)
                messeageQueueService.SendMessage("Book Deleted");

            return response;
        }
    }
}
