using System.Text.Json;
using Crew;
using EventBusConnection.Client;
using EventBusConnection.Event;
using EventBusConnection.Event.Events;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;

namespace CrewEvent.Eventhandlers;

public class CheckCrewMemberHealthEventsHandler : IEventHandler {
    public Task Execute(IServiceScopeFactory serviceScopeFactory, string eventMessage) {
        var scope = serviceScopeFactory.CreateScope();
        var eventPublisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>();

        var channel = GrpcChannel.ForAddress("http://localhost:5151");
        var client = new Crew.Crew.CrewClient(channel);

        var response = client.ReadCrew(new Empty());

        List<int> crewIds = response.Crew.ToList().Where(c => c.Health < 5).Select(c => c.CrewMemberId).ToList();

        if (crewIds.Count > 0)
            eventPublisher.Publish(
                JsonSerializer.Serialize(new CrewMemberCriticalHealthEvent(crewIds)));
        
        return Task.CompletedTask;
    }
}