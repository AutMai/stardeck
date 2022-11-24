using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace EventBusConnection.Client; 

public class EventPublisher : IEventPublisher{
    private readonly IConfiguration _configuration;

    private readonly string _exchangeName;
    private readonly IModel _channel;
    private readonly IConnection _connection;
    
    public EventPublisher(IConfiguration configuration) {
        _configuration = configuration;

        var factory = new ConnectionFactory() {
            HostName = _configuration["RabbitMQHost"],
            Port = int.Parse(_configuration["RabbitMQPort"])
        };

        _exchangeName = _configuration["EventBusExchange"];

        try {
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _connection.ConnectionShutdown += ShutDownMessagBroker;
        } catch (Exception e) {
            Console.WriteLine($"failed: {e}");
        }
    }

    private void ShutDownMessagBroker(object sender, ShutdownEventArgs arg) => Console.WriteLine("Eventbus Shutdown");
    
    public void Publish(string message) {
        var body = Encoding.UTF8.GetBytes(message);
        
        _channel.BasicPublish(_exchangeName, "", null, body);
    }

    public void Dispose() {
        if (_channel.IsOpen) {
            _channel.Close();
            _connection.Close();
        }
    }
}