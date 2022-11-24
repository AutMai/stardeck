namespace EventBusConnection.Event.Events; 

public record SystemDamagedEvent(int systemId) : EventRecord("SYSTEM_DAMAGED");