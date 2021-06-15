using Microsoft.Azure.ServiceBus;
using ServiceBus.Interfaces;
using ServiceBus.Models;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceBusReceiver
{
    public class QueueReceiverService : IQueueReceiverService
    {
        private readonly string _queueName;

        private readonly string _queueStringConnection;

        private IQueueClient _queueClient;

        public QueueReceiverService(string queueName, string queueStringConnection)
        {
            _queueName = queueName;
            _queueStringConnection = queueStringConnection;
        }

        public async Task ReadMessageAsync()
        {
            _queueClient = new QueueClient(_queueStringConnection, _queueName, ReceiveMode.PeekLock, RetryPolicy.Default);

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceiverHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _queueClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);

            Console.ReadLine();

            await _queueClient.CloseAsync();
        }

        private Task ExceptionReceiverHandler(ExceptionReceivedEventArgs arg)
        {
            Console.WriteLine("Error recieving the messagem:" + arg.Exception);
            return Task.CompletedTask;
        }

        private async Task ProcessMessageAsync(Message message, CancellationToken token)
        {
            var messageStr = Encoding.UTF8.GetString(message.Body);
            var model = JsonSerializer.Deserialize<Usuario>(messageStr);
            Console.WriteLine($"Received: {model}");

            await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }
    }
}
