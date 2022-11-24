using System.Text.Json;
using EventBusConnection.Event;
using EventBusConnection.Event.Events;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace MaintenanceEvent.EventHandlers; 

public class DepartedFromLocationEventHandler:IEventHandler {
    public async Task Execute(IServiceScopeFactory serviceScopeFactory, string eventMessage) {
        var e = JsonSerializer.Deserialize<DepartedFromLocationEvent>(eventMessage);
        using var scope = serviceScopeFactory.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IRepository<ShipInfo>>();
        var shipInfo = (await repo.ReadAsync(e.shipId));
        if (shipInfo is null) return;
        Console.WriteLine("Departed from location: " + shipInfo.CurrentLocation);
        shipInfo.CurrentLocation = "Space";
        await repo.UpdateAsync(shipInfo);
    }
}