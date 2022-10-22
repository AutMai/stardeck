namespace EventBusConnection.EventsProcessing; 

public interface IEventProcessor {
    void ProcessEvent(string message);
}