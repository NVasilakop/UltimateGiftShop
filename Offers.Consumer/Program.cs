using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Offers.Consumer.Abstractions;
using Offers.Consumer.Services;
using StackExchange.Redis;

namespace Offers.Consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddSingleton<IRabbitMQClientFactory,RabbitMQClientFactory>();
                    services.AddSingleton<IRabbitMQConsumer,RabbitMQConsumer>();
                    services.AddSingleton<ICustomerWriterService,CustomerWriterService>();
                    services
                        .AddSingleton<IConnectionMultiplexer>(sp =>
                        {
                            var configurationOptions = new ConfigurationOptions
                            {
                                ClientName = "UltimateGiftShop",
                                ConnectTimeout = 5000,
                                SyncTimeout = 5000,
                                AsyncTimeout = 5000
                            };
                            configurationOptions.EndPoints.Add("127.0.0.1",6379);
                            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(configurationOptions);
                            connection.ConnectionFailed += (sender, e) =>
                            {
                                // logger.LogError($"Connection to Redis failed with type {e.FailureType}", e.Exception);
                                //TODO Do something with readiness etc
                            };

                            return connection;
                        });
                });
    }
}
