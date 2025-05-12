using RabbitMQ.Client;
using System.Text;

namespace ExpenseService.RabbitMQ
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IRabbitMQConnection _rabbitMqConnection;
        public EventPublisher(IRabbitMQConnection rabbitMQConnection)
        {
            _rabbitMqConnection = rabbitMQConnection;
        }

        public async Task Publish(string queue, string message)
        {
            using var channel = await _rabbitMqConnection.CreateChannel();
            await channel.QueueDeclareAsync(queue: queue, durable: true, exclusive: false, autoDelete: false);
            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(
                exchange: string.Empty, 
                routingKey: queue,
                mandatory: true,
                basicProperties: new BasicProperties { Persistent = true}, 
                body: body);
        }
    }
}
