using System.Text.Json;
using Crew;
using EventBusConnection.Event;
using EventBusConnection.Event.Events;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using MaintenanceDomain.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CrewEvent.Eventhandlers;

public class HealCrewMemberEventHandler : IEventHandler {
    public Task Execute(IServiceScopeFactory serviceScopeFactory, string eventMessage) {
        var e = JsonSerializer.Deserialize<HealCrewMemberEvent>(eventMessage);

        var channel = GrpcChannel.ForAddress("http://localhost:5151");
        var client = new Crew.Crew.CrewClient(channel);

        if (e.crewMemberIds.Count == 0) {
            foreach (var crew in client.ReadCrew(new Empty()).Crew) {
                client.UpdateCrew(new UpdateCrewRequest() {
                    CrewMemberId = crew.CrewMemberId,
                    Health = 100
                });
            }
        }
        else {
            foreach (var crewId in e.crewMemberIds) {
                client.UpdateCrew(new UpdateCrewRequest() {
                    CrewMemberId = crewId,
                    Health = 100
                });
            }
        }

        return Task.CompletedTask;
    }
}