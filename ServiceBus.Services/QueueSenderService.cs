using Microsoft.Azure.ServiceBus;
using ServiceBus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceBus.Services
{
    public class QueueSenderService : IQueueSenderService
    {
        private readonly string _queueName;

        private readonly string _queueStringConnection;

        public QueueSenderService(string queueName, string queueStringConnection)
        {
            _queueName = queueName;
            _queueStringConnection = queueStringConnection;
        }

        public async Task SendMessageAsync<T>(T serviceBuseMessage)
        {
            var queueClient = new QueueClient(_queueStringConnection, _queueName, ReceiveMode.PeekLock, RetryPolicy.Default);
            var messageStr = JsonSerializer.Serialize(serviceBuseMessage);
            var message = new Message(Encoding.UTF8.GetBytes(messageStr));

            await queueClient.SendAsync(message);
        }
    }
}
