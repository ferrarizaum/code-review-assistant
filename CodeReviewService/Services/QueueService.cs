using RabbitMQ.Client;
using System.Text;

namespace CodeReviewService.Services
{
    public interface IQueueService
    {
        void PublishMessageAsync(string message);
    }

    public class QueueService : IQueueService
    {
        private readonly ConnectionFactory _factory;
        private readonly ILogger<QueueService> _logger;
        public QueueService(ILogger<QueueService> logger)
        {
            _factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            _logger = logger;
        }

        public async void PublishMessageAsync(string message)
        {
            using var connection = await _factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: "myQueue", 
                durable: false, 
                exclusive: false, 
                autoDelete: false, 
                arguments: null
            );

            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(
                exchange: string.Empty, 
                routingKey: "myQueue", 
                body: body
            );

            _logger.LogInformation("Message published");
        }
    }
}
