using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace TransactionService.RabbitMQ
{
    public class EventConsumer : IEventConsumer
    {
        private readonly IRabbitMQConnection _rabbitMqConnection;
        public EventConsumer(IRabbitMQConnection rabbitMQConnection)
        {
            _rabbitMqConnection = rabbitMQConnection;
        }

        public async Task Consume (string queue)
        {
            using var channel = await _rabbitMqConnection.CreateChannel();
            // declare the queue 
            await channel.QueueDeclareAsync(queue: queue, durable: true, exclusive: false, autoDelete: false);
            
            // define the consumer
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += EventReceived;
            await channel.BasicConsumeAsync(queue, autoAck: false, consumer);
            Console.WriteLine("Waiting for messages...");
        }

        private async Task EventReceived(object sender, BasicDeliverEventArgs @event)
        {
            byte[] body = @event.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);

            Console.Write($"Received message -  {message}");

            // Acknowledge the message
            await  ((AsyncEventingBasicConsumer)sender)
                .Channel.BasicAckAsync(@event.DeliveryTag, multiple: false);
        }
    }
}
