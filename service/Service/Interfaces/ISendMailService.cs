
using service.Domain;

namespace service.service.Interfaces
{
    public interface ISendMailService
    {
        public Task SendMessageAsync(SendMessageRequest model);
    }
}