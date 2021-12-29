using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Offers.Consumer.Abstractions;

namespace Offers.Consumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IRabbitMQClientFactory _factory;
        private readonly IRabbitMQConsumer _consumer;

        public Worker(ILogger<Worker> logger, IRabbitMQClientFactory fact, IRabbitMQConsumer cons)
        {
            _logger = logger;
            _factory = fact;
            _consumer = cons;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _factory.CreateConnection();
                _consumer.Consume();
                _consumer.ConsumeCustomers();
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
