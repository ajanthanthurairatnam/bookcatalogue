namespace BookCatalogue.Application.Services
{
    public interface IMesseageQueueService
    {
        void SendMessage(string message);
    }

}
