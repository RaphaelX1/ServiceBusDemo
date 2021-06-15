using System.Threading.Tasks;

namespace ServiceBus.Interfaces
{
    public interface IQueueReceiverService
    {
        Task ReadMessageAsync();
    }
}