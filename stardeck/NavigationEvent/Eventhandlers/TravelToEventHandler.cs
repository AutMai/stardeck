using System.Text.Json;
using EventBusConnection.Client;
using EventBusConnection.Event;
using EventBusConnection.Event.Events;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace NavigationEvent.EventHandlers;

public class TravelToEventHandler : IEventHandler {
    public async Task Execute(IServiceScopeFactory serviceScopeFactory, string eventMessage) {
        var e = JsonSerializer.Deserialize<TravelToEvent>(eventMessage);

        var scope = serviceScopeFactory.CreateScope();
        var eventPublisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>();
        
        eventPublisher.Publish(JsonSerializer.Serialize(new ArrivedAtLocationEvent(1, e.location)));
    }
}