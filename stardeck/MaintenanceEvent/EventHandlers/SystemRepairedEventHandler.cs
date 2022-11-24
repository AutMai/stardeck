using System.Text.Json;
using EventBusConnection.Event;
using EventBusConnection.Event.Events;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace MaintenanceEvent.EventHandlers;

public class SystemRepairedEventHandler : IEventHandler {
    public async Task Execute(IServiceScopeFactory serviceScopeFactory, string eventMessage) {
        var e = JsonSerializer.Deserialize<SystemRepairedEvent>(eventMessage);

        using var scope = serviceScopeFactory.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IRepository<MaintenanceModel.Entities.System>>();
        var system = await repo.ReadAsync(e.systemId);
        system.Status = "Operational";
        await repo.UpdateAsync(system);
    }
}