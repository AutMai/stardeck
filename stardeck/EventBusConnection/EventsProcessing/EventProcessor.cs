using System.Text.Json;
using EventBusConnection.EventsProcessing.Events;
using Microsoft.Extensions.DependencyInjection;

namespace EventBusConnection.EventsProcessing;

public class EventProcessor<TVisitor> : IEventProcessor where TVisitor : IVisitor, new() {
    private readonly IServiceScopeFactory _scopeFactory;

    public EventProcessor(IServiceScopeFactory scopeFactory) {
        _scopeFactory = scopeFactory;
    }

    private EventType DetermineEvent(string message) {
        using var jsonDoc = JsonDocument.Parse(message);
        var e = jsonDoc.RootElement.GetProperty("Type").GetString();
        return Enum.Parse<EventType>(e);
    }

    public void ProcessEvent(string message) {
        var eventType = DetermineEvent(message);
        BaseEvent e = (eventType switch {
            EventType.ArrivedAtLocation => JsonSerializer.Deserialize<ArrivedAtLocationEvent>(message),
            EventType.DepartedFromLocation => JsonSerializer.Deserialize<DepartedFromLocationEvent>(message),
            _ => JsonSerializer.Deserialize<BaseEvent>(message)
        })!;
        e.Accept(new TVisitor {ScopeFactory = _scopeFactory});
    }
}