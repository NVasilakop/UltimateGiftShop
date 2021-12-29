using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Offers.Consumer.Abstractions;

namespace Offers.Consumer
{
    public class CustomerWorker : BackgroundService
    {
        private readonly ICustomerWriterService _customerService;

        public CustomerWorker(ICustomerWriterService _serv)
        {
            _customerService = _serv;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
                try
                {
                    // _logger.LogInformation($"OffersWriter running at: {DateTimeOffset.Now}");
                    // await _consumer.ConsumeAsync(stoppingToken);
                }
                // catch (OperationCanceledException oex) when (oex.CancellationToken == stoppingToken)
                // {
                //     _logger.LogInformation($"{nameof(TerService)} Worker stopped");
                // }
                catch (Exception ex)
                {
                    // _logger.LogError(ex, $"{nameof(OffersWriter)} Worker threw an exception {ex.Message}");
                }
            return Task.CompletedTask;
        }
    }
}