namespace EventBusConnection.Event; 

public interface IEventProcessor {
    void ProcessEvent(string eventMessage);
}