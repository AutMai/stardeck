using System.Text.Json;
using EventBusConnection.Event;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace MaintenanceEvent.EventHandlers;

public class RefillInventoryEventHandler : IEventHandler
{
    public async Task Execute(IServiceScopeFactory serviceScopeFactory, string eventMessage)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IRepository<Inventory>>();

        var inventories = await repo.ReadAsync();
        foreach (var inventory in inventories)
        {
            inventory.Amount += 10;
            await repo.UpdateAsync(inventory);
        }
    }
}