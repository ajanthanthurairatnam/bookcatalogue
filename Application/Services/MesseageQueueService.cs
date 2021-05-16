using Microsoft.Extensions.Logging;

namespace BookCatalogue.Application.Services
{
    public class MesseageQueueService : IMesseageQueueService
    {       
        private readonly ILogger<MesseageQueueService> logger;
        public MesseageQueueService(ILogger<MesseageQueueService> logger)
        {
            this.logger = logger;
        }
        public void SendMessage(string message)
        {
            logger.LogInformation(message);
        }
    }

}
