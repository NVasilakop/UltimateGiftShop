using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Offers.Consumer.Abstractions;
using Offers.Consumer.Data;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StackExchange.Redis;

namespace Offers.Consumer.Services
{
    public class RabbitMQConsumer : IRabbitMQConsumer
    {
        private readonly IConnectionMultiplexer _connection;
        private readonly ICustomerWriterService _writerService;

        public RabbitMQConsumer(IConnectionMultiplexer conn, ICustomerWriterService writerService)
        {
            _connection = conn;
            _writerService = writerService;
        }

        public void Consume()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("offers_giftshop_msg_queue", true, consumer);

                    BasicDeliverEventArgs deliveryArguments = consumer.Queue.Dequeue() as BasicDeliverEventArgs;
                    String jsonified = Encoding.UTF8.GetString(deliveryArguments.Body);
                    OfferMsg offer = JsonConvert.DeserializeObject<OfferMsg>(jsonified);
                    channel.BasicAck(deliveryArguments.DeliveryTag, false);

                    RedisKey key = new RedisKey(string.Join("_", "offermsg", offer.CustomerType, offer.Product));
                    HashEntry[] hashEntries = new HashEntry[]
                    {
                        new HashEntry("customerType", offer.CustomerType.ToString()), new HashEntry("discount", offer.Discount.ToString()), new HashEntry("product", offer.Product.ToString()), new HashEntry("startDate", offer.StartDate.ToString()),
                        new HashEntry("endDate", offer.EndDate.ToString())
                    };
                    _connection.GetDatabase().HashSet(key, hashEntries);

                }
            }
        }
        public bool ConsumeCustomers()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("offers_giftshop_customers_queue", true, consumer);

                    BasicDeliverEventArgs deliveryArguments1 = consumer.Queue.Dequeue() as BasicDeliverEventArgs;
                    String jsonified1 = Encoding.UTF8.GetString(deliveryArguments1.Body);
                    IList<Customer> customers = JsonConvert.DeserializeObject<IList<Customer>>(jsonified1);
                    channel.BasicAck(deliveryArguments1.DeliveryTag, false);

                    return _writerService.WriteToRedis(customers);
                }
            }
        }
    }
}