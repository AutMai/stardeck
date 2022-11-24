using System.Text;
using EventBusConnection.EventsProcessing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EventBusConnection;

public class EventSubscriber : BackgroundService {
    private IConfiguration _configuration;
    private IConnection _connection;
    private IModel _channel;
    private IEventProcessor _eventProcessor;
    private string _exchange;
    private string _queueName;

    public EventSubscriber(IConfiguration configuration, IEventProcessor processor
    ) {
        _configuration = configuration;
        _eventProcessor = processor;
        
        _exchange = _configuration["EventBusExchange"];
        var factory = new ConnectionFactory() {
            HostName = _configuration["RabbitMQHost"],
            Port = int.Parse(_configuration["RabbitMQPort"])
        };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.ExchangeDeclare(_exchange, ExchangeType.Fanout);
        _queueName = _channel.QueueDeclare().QueueName; // brauchen wir wenn wir queue nicht über browser erstellt haben
        _channel.QueueBind(_queueName, _exchange, ""); // _,,_
    }

    protected override Task ExecuteAsync(CancellationToken token) {
        token.ThrowIfCancellationRequested();
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (_, ea) => {
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());
            _eventProcessor.ProcessEvent(message);
        };

        _channel.BasicConsume(_queueName, true, consumer);
        return Task.CompletedTask;
    }
}