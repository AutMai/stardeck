using RabbitMQ.Client;

namespace EventBusConnection;

public class Connector {
    private const string UserName = "guest";

    private const string Password = "guest";

    private const string HostName = "localhost";

    private const int Port = 5762;


    public void Init() {
        var connectionFactory = new RabbitMQ.Client.ConnectionFactory() {
            Uri = new Uri("amqp://guest:guest@localhost:5672/")
        };

        Console.WriteLine(connectionFactory.Uri);

        var connection = connectionFactory.CreateConnection();

        var model = connection.CreateModel();

        model.ExchangeDeclare("stardeckExchange", ExchangeType.Fanout);
        model.QueueDeclare("navigationQueue", true, false, false, null);
        model.QueueDeclare("crewQueue", true, false, false, null);
        model.QueueDeclare("maintenanceQueue", true, false, false, null);
        model.QueueBind("navigationQueue", "stardeckExchange", "", null);
        model.QueueBind("crewQueue", "stardeckExchange", "", null);
        model.QueueBind("maintenanceQueue", "stardeckExchange", "", null);
    }

    public IModel GetModel() {
        var connectionFactory = new RabbitMQ.Client.ConnectionFactory() {
            Uri = new Uri("amqp://guest:guest@localhost:5672/")
        };

        var connection = connectionFactory.CreateConnection();

        return connection.CreateModel();
    }
}