using System.Text.Json;
using System.Text.Json.Serialization;
using EventBusConnection.Client;
using EventBusConnection.Event;
using EventBusConnection.Event.Events;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CrewEvent.Eventhandlers;

public class SystemDamagedEventHandler : IEventHandler {
    public async Task Execute(IServiceScopeFactory serviceScopeFactory, string eventMessage) {
        var e = JsonSerializer.Deserialize<SystemDamagedEvent>(eventMessage);

        using var scope = serviceScopeFactory.CreateScope();
        var eventPublisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>();

        await Task.Delay(10000);
        var message = JsonSerializer.Serialize(new SystemRepairedEvent(e.systemId));
        eventPublisher.Publish(message);
    }
}