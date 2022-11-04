using EventBusConnection.EventsProcessing;
using EventBusConnection.EventsProcessing.Events;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Entities;

namespace CrewAPI.EventProcessors;

public class CrewEventVisitor : IVisitor {
    public IServiceScopeFactory ScopeFactory { get; init; }

    public CrewEventVisitor() {
    }

    public CrewEventVisitor(IServiceScopeFactory scopeFactory) {
        ScopeFactory = scopeFactory;
    }


    public async Task Visit(ArrivedAtLocationEvent e) {
        throw new NotImplementedException();
    }

    public async Task Visit(DepartedFromLocationEvent e) {
        throw new NotImplementedException();
    }

    public async Task Visit(SystemDamagedEvent token)
    {
        throw new NotImplementedException();
    }

    public async Task Visit(SystemRepairedEvent token)
    {
        throw new NotImplementedException();
    }

    public async Task Visit(IntrudersDetectedEvent token)
    {
        Console.WriteLine("Send Guards");
        using var scope = ScopeFactory.CreateScope();

    }
}