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
        var shipRepository = scope.ServiceProvider.GetRequiredService<IRepository<ShipInfo>>();
        var eventPublisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>();

        int shipId = (await shipRepository.ReadAsync()).First().ShipId;

        eventPublisher.Publish(JsonSerializer.Serialize(new ArrivedAtLocationEvent(
            (await shipRepository.ReadAsync()).First().ShipId, e.location)));
    }
}