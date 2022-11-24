namespace EventBusConnection.Event.Events; 

public record DepartedFromLocationEvent(int shipId) : EventRecord("DEPARTED_FROM_LOCATION");