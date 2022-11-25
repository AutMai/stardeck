using System.Text.Json;
using EventBusConnection.Client;
using EventBusConnection.Event;
using EventBusConnection.Event.Events;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace MaintenanceEvent.EventHandlers;

public class StocktakingEventHandler : IEventHandler {
    public async Task Execute(IServiceScopeFactory serviceScopeFactory, string eventMessage) {
        var e = JsonSerializer.Deserialize<StocktakingEvent>(eventMessage);

        using var scope = serviceScopeFactory.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IRepository<Inventory>>();

        var inventories = await repo.ReadAsync(x => x.Amount < 5);
        if (inventories.Count > 0) {
            var eventPublisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>();
            eventPublisher.Publish(JsonSerializer.Serialize(new TravelToEvent("Baumax")));
        }
    }
}