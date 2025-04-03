using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CommentService.Services
{
    public class QueueService : BackgroundService
    {
        private readonly ConnectionFactory _factory;
        private readonly ILogger<QueueService> _logger;
        private IConnection _connection;
        private IChannel _channel;  

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

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _connection = await _factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();  

            await _channel.QueueDeclareAsync(
                queue: "myQueue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            _logger.LogInformation("RabbitMQ connection and channel established.");
            await base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                _logger.LogInformation("Message received: {message}", message);

                await Task.CompletedTask;
            };

            await _channel.BasicConsumeAsync(queue: "myQueue", autoAck: true, consumer: consumer);

            _logger.LogInformation("Listener started. Waiting for messages...");

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _channel?.CloseAsync();
            _connection?.CloseAsync();
            _logger.LogInformation("RabbitMQ consumer stopped.");
            return base.StopAsync(cancellationToken);
        }
    }
}
