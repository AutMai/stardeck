using System;
using System.Linq;
using System.Threading.Tasks;
using EventBusConnection.EventsProcessing;
using EventBusConnection.EventsProcessing.Events;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace MaintenanceAPI.EventProcessors;

public class MaintenanceEventVisitor : IVisitor {
    public IServiceScopeFactory ScopeFactory { get; init; }

    public MaintenanceEventVisitor() {
    }

    public MaintenanceEventVisitor(IServiceScopeFactory scopeFactory) {
        ScopeFactory = scopeFactory;
    }


    public async Task Visit(ArrivedAtLocationEvent e) {
        Console.WriteLine("Arrived at location: " + e.Location);
        using var scope = ScopeFactory.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IRepository<ShipInfo>>();
        var shipInfo = (await repo.ReadAsync()).FirstOrDefault();
        if (shipInfo is null) return;
        shipInfo.CurrentLocation = e.Location;
        await repo.UpdateAsync(shipInfo);
    }

    public async Task Visit(DepartedFromLocationEvent e) {
        Console.WriteLine("Departed from location: " + e.Location);
        using var scope = ScopeFactory.CreateScope();
        var repo = scope.ServiceProvider.GetRequiredService<IRepository<ShipInfo>>();
        var shipInfo = (await repo.ReadAsync()).FirstOrDefault();
        if (shipInfo is null) return;
        shipInfo.CurrentLocation = "Space";
        await repo.UpdateAsync(shipInfo);
    }
}