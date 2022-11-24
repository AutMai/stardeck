namespace EventBusConnection.Events; 

public interface IEventHandler {
    void Execute();
}