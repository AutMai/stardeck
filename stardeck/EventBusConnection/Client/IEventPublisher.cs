namespace EventBusConnection.Client; 

public interface IEventPublisher {
    void Publish(string message);
}