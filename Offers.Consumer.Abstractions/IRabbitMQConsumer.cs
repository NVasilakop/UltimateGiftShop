namespace Offers.Consumer.Abstractions
{
    public interface IRabbitMQConsumer
    {
        void Consume();
        bool ConsumeCustomers();
    }
}