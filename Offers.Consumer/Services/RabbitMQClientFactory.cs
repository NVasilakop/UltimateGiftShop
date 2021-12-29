using Offers.Consumer.Abstractions;
using RabbitMQ.Client;

namespace Offers.Consumer.Services
{
    public class RabbitMQClientFactory : IRabbitMQClientFactory
    {

        public void CreateConnection()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("offers_giftshop_msg",ExchangeType.Direct);
                    channel.QueueDeclare("offers_giftshop_msg_queue",true,false,false,null);
                    channel.QueueBind("offers_giftshop_msg_queue","offers_giftshop_msg","1");
                    
                    channel.ExchangeDeclare("offers_giftshop_customers",ExchangeType.Direct);
                    channel.QueueDeclare("offers_giftshop_customers_queue",true,false,false,null);
                    channel.QueueBind("offers_giftshop_customers_queue","offers_giftshop_customers","1");
                }
            }
        }
    }
}