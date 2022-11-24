using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace EventBusConnection.Event;

public class AEventProcessor : Dictionary<string, IEventHandler>, IEventProcessor {
    protected readonly IServiceScopeFactory ScopeFactory;
    
    public AEventProcessor(IServiceScopeFactory scopeFactory) {
        ScopeFactory = scopeFactory;
    }

    public void ProcessEvent(string eventMessage) {
        var eventRecord = JsonSerializer.Deserialize<EventRecord>(eventMessage);
        if (!ContainsKey(eventRecord.Type)) return;
        
        var eventHandler = this[eventRecord.Type];
        eventHandler.Execute(ScopeFactory, eventMessage);
    }
}