namespace EventBusConnection.Event.Events; 

public record LogEvent(string title, string content, int author) : EventRecord("LOG");