namespace Offers.Consumer.Abstractions
{
    public interface IRabbitMQClientFactory
    {
        void CreateConnection();
    }
}