namespace ExpenseService.RabbitMQ
{
    public interface IEventPublisher
    {
        Task Publish(string queue, string message);
    }
}
