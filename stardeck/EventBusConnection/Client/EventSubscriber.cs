using System.Text;
using EventBusConnection.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EventBusConnection.Client;

public class EventSubscriber : BackgroundService {
    private readonly IConfiguration _configuration;
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _queueName;

    private readonly IEventProcessor _eventProcessor;

    public EventSubscriber(IConfiguration configuration, IEventProcessor eventProcessor) {
        _configuration = configuration;

        var factory = new ConnectionFactory() {
            HostName = _configuration["RabbitMQHost"],
            Port = int.Parse(_configuration["RabbitMQPort"])
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _queueName = _configuration["EventBusQueue"];

        _eventProcessor = eventProcessor;
    }


    protected override Task ExecuteAsync(CancellationToken stoppingToken) {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += (moduleHandle, message) => {
            var body = message.Body;
            var eventMessage = Encoding.UTF8.GetString(body.ToArray());

            _eventProcessor.ProcessEvent(eventMessage);
        };

        _channel.BasicConsume(_queueName, true, consumer);
        return Task.CompletedTask;
    }
}