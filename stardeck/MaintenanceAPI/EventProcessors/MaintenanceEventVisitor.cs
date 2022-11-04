using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EventBusConnection;
using EventBusConnection.EventsProcessing;
using EventBusConnection.EventsProcessing.Events;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System = MaintenanceModel.Entities.System;

namespace MaintenanceAPI.EventProcessors;

public class MaintenanceEventVisitor : IVisitor
{
    public IServiceScopeFactory ScopeFactory { get; init; }

    public MaintenanceEventVisitor()
    {
    }

    public MaintenanceEventVisitor(IServiceScopeFactory scopeFactory)
    {
        ScopeFactory = scopeFactory;
    }


    public async Task Visit(ArrivedAtLocationEvent e)
    {
        Console.WriteLine("Arrived at location: " + e.Location);
        using var scope = ScopeFactory.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IRepository<ShipInfo>>();
        var shipInfo = (await repo.ReadAsync()).FirstOrDefault();
        if (shipInfo is null) return;
        shipInfo.CurrentLocation = e.Location;
        await repo.UpdateAsync(shipInfo);
    }

    public async Task Visit(DepartedFromLocationEvent e)
    {
        Console.WriteLine("Departed from location: " + e.Location);
        using var scope = ScopeFactory.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IRepository<ShipInfo>>();
        var shipInfo = (await repo.ReadAsync()).FirstOrDefault();
        if (shipInfo is null) return;
        shipInfo.CurrentLocation = "Space";
        await repo.UpdateAsync(shipInfo);
    }

    public Task Visit(SystemDamagedEvent token)
    {
        return Task.CompletedTask;
    }

    public async Task Visit(SystemRepairedEvent token)
    {
        using var scope = ScopeFactory.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IRepository<MaintenanceModel.Entities.System>>();

        var system = (await repo.ReadAsync(s => s.SystemId == token.System.SystemId)).FirstOrDefault();
        system.Status = "Operational";
        await repo.UpdateAsync(system);
    }

    public Task Visit(IntrudersDetectedEvent token) {
        return Task.CompletedTask;
    }
}