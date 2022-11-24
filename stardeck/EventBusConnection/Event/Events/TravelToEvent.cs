namespace EventBusConnection.Event.Events; 

public record TravelToEvent(string location) : EventRecord("TRAVEL_TO");