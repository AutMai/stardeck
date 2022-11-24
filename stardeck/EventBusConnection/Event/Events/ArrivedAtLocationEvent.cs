namespace EventBusConnection.Event.Events; 

public record ArrivedAtLocationEvent(int shipId, string location) : EventRecord("ARRIVED_AT_LOCATION");