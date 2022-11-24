namespace EventBusConnection.Events; 

public interface IEventProcessor {
    void ProcessEvent(string eventMessage);
}