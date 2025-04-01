using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CommentService.Services
{
    public interface IQueueService
    {
        void StartListening();
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

        public async void StartListening()
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

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                _logger.LogInformation("Message received: {message}", message);

                await Task.CompletedTask;
            };

            await channel.BasicConsumeAsync(
                queue: "myQueue",
                autoAck: true,
                consumer: consumer
            );

            _logger.LogInformation("Listener started. Waiting for messages...");

            Console.ReadLine();
        }
    }
}
