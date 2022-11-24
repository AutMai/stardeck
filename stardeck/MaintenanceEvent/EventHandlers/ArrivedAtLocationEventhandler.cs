using System.Text.Json;
using EventBusConnection.Client;
using EventBusConnection.Event;
using EventBusConnection.Event.Events;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace MaintenanceEvent.EventHandlers;

public class ArrivedAtLocationEventHandler : IEventHandler {
    public async Task Execute(IServiceScopeFactory serviceScopeFactory, string eventMessage) {
        var e = JsonSerializer.Deserialize<ArrivedAtLocationEvent>(eventMessage);
        Console.WriteLine("Arrived at location: " + e.location);

        using var scope = serviceScopeFactory.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IRepository<ShipInfo>>();

        var shipInfo = (await repo.ReadAsync(e.shipId));
        if (shipInfo is null) return;

        shipInfo.CurrentLocation = e.location;
        await repo.UpdateAsync(shipInfo);

        var eventPublisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>();
        if (e.location == "HospitalIsland") {
            eventPublisher.Publish(JsonSerializer.Serialize(new HealCrewMemberEvent(new List<int>())));
        }
        if (e.location == "Baumax") {
            eventPublisher.Publish(JsonSerializer.Serialize(new RefillInventoryEvent()));
        }
    }
}