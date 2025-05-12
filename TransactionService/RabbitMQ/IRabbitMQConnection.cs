using RabbitMQ.Client;
namespace TransactionService.RabbitMQ
{
    public interface IRabbitMQConnection : IDisposable
    {
        Task<IChannel> CreateChannel();
        bool IsConnected { get; }
        Task<bool> TryConnect();
    }
}
