namespace EventBusConnection;

public interface IEventBusClient {
    void Publish(string message);
}