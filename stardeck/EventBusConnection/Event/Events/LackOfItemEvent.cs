namespace EventBusConnection.Event.Events;

public record LackOfItemEvent(int itemId) : EventRecord("LACK_OF_ITEM");