using System.Text.Json;
using System.Text.Json.Serialization;
using EventBusConnection.Client;
using EventBusConnection.Event;
using EventBusConnection.Event.Events;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CrewEvent.Eventhandlers;

public class SystemDamagedEventHandler : IEventHandler {
    public async Task Execute(IServiceScopeFactory serviceScopeFactory, string eventMessage) {
        var e = JsonSerializer.Deserialize<SystemDamagedEvent>(eventMessage);

        using var scope = serviceScopeFactory.CreateScope();
        var eventPublisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>();


        var channel = GrpcChannel.ForAddress("http://localhost:5151");
        var client = new Crew.Crew.CrewClient(channel);

        var res = await client.ReadCrewAsync(new Empty());

        while (!res.Crew.ToList().Exists(c => c.Role == "Mechanic" && c.Health > 10)) {
            await Task.Delay(10000);
            res = await client.ReadCrewAsync(new Empty());
        }
        
        
        await Task.Delay(10000);
        var message = JsonSerializer.Serialize(new SystemRepairedEvent(e.systemId));
        eventPublisher.Publish(message);
    }
}