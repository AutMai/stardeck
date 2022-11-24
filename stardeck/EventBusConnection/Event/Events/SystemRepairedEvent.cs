namespace EventBusConnection.Event.Events; 

public record SystemRepairedEvent(int systemId) : EventRecord("SYSTEM_REPAIRED");