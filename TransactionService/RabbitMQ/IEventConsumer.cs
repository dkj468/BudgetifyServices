namespace TransactionService.RabbitMQ
{
    public interface IEventConsumer
    {
        Task Consume(string queue);
    }
}
