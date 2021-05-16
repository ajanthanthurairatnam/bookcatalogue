using BookCatalogue.Application.Enums;

namespace BookCatalogue.Application.Common
{
    public abstract class ResponseMessage
    {
        public Status Status { get; set; } = Status.Unknown;
        public string Message { get; set; }
    }
}
