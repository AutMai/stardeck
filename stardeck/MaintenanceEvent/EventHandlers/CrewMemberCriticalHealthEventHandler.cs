using System.Text.Json;
using EventBusConnection.Client;
using EventBusConnection.Event;
using EventBusConnection.Event.Events;
using MaintenanceDomain.Repositories.Implementations;
using MaintenanceDomain.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MaintenanceEvent.EventHandlers;

public class CrewMemberCriticalHealthEventHandler : IEventHandler {
    public async Task Execute(IServiceScopeFactory serviceScopeFactory, string eventMessage) {
        var e = JsonSerializer.Deserialize<CrewMemberCriticalHealthEvent>(eventMessage);

        var scope = serviceScopeFactory.CreateScope();
        var systemRepository =
            scope.ServiceProvider.GetRequiredService<IRepository<MaintenanceModel.Entities.System>>();
        var eventPublisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>();

        var system = await systemRepository.ReadAsync();
        eventPublisher.Publish(system.Exists(s => s.GetType().Name == "RehabilitationSystem")
            ? JsonSerializer.Serialize(new HealCrewMemberEvent(e.crewMemberIds))
            : JsonSerializer.Serialize(new TravelToEvent("HospitalIsland")));
    }
}