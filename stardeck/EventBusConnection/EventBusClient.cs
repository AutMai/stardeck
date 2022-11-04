using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace EventBusConnection;

public class EventBusClient : IEventBusClient {
    private readonly string _exchange;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public EventBusClient(IConfiguration configuration) {
        var configuration1 = configuration;
        _exchange = configuration1["EventBusExchange"];

        var factory = new ConnectionFactory() {
            Uri = new Uri($"amqp://guest:guest@{configuration1["RabbitMQHost"]}:{configuration1["RabbitMQPort"]}/")
        };
        try {
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(
                _exchange, ExchangeType.Fanout
            );
            _connection.ConnectionShutdown += ShutDownMessageBroker;
        }
        catch (Exception ex) {
            Console.WriteLine($"failed: {ex}");
        }
    }

    public void Publish(string message) {
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(_exchange, "", null, body);
    }

    private void ShutDownMessageBroker(
        object? sender, ShutdownEventArgs arg
    ) => Console.WriteLine("Eventbus Shutdown");

    public void Dispose() {
        if (_channel.IsClosed) return;
        _channel.Close();
        _connection.Close();
    }
}