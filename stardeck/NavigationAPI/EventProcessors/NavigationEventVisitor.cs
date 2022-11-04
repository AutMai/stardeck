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
}