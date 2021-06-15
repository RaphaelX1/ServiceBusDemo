using System.Threading.Tasks;

namespace ServiceBus.Interfaces
{
    public interface IQueueSenderService
    {
        Task SendMessageAsync<T>(T serviceBuseMessage);
    }
}