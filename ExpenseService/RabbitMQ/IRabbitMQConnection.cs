using RabbitMQ.Client;
namespace ExpenseService.RabbitMQ
{
    public interface IRabbitMQConnection : IDisposable
    {
        Task<IChannel> CreateChannel();
        bool IsConnected { get; }
        Task<bool> TryConnect();
    }
}
