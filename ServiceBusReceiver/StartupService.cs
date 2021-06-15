using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceBusReceiver
{
    public class StartupService : IHostedService
    {
        private IServiceProvider services;

        public StartupService(IServiceProvider services)
        {
            this.services = services;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var scope = services.CreateScope();
            var queueReceiverService = scope.ServiceProvider.GetRequiredService<QueueReceiverService>();
            await queueReceiverService.ReadMessageAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
