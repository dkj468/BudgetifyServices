using RabbitMQ.Client;

namespace ExpenseService.RabbitMQ
{
    public class RabbitMQConnection : IRabbitMQConnection
    {
        private readonly IConnectionFactory _connectionFactory;
        private IConnection _connection;
        private bool _disposed;

        public RabbitMQConnection (IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException (nameof (connectionFactory));
        }
        public bool IsConnected => _connection is { IsOpen: true } && !_disposed;


        public Task<IChannel> CreateChannel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("No RabbitMQ connection is available"); 
            }
            return _connection.CreateChannelAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> TryConnect()
        {
            try
            {
                _connection = await _connectionFactory.CreateConnectionAsync();
                return IsConnected;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_disposed) return;

            try
            {
                _connection?.Dispose();
            }
            catch (IOException)
            {
                // Log error if needed
            }

            _disposed = true;
            await Task.CompletedTask;
        }
    }
}
