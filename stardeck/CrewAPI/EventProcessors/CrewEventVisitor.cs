using System.Text.Json;
using Crew;
using EventBusConnection;
using EventBusConnection.EventsProcessing;
using EventBusConnection.EventsProcessing.Events;
using Grpc.Net.Client;
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

    public async Task Visit(SystemDamagedEvent token) {
        var channel = GrpcChannel.ForAddress("http://localhost:5151");
        Crew.Crew.CrewClient client = new Crew.Crew.CrewClient(channel);
        client.CreateLogbookEntry(new LogbookEntryRequest() {
            AuthorId = 1,
            Content = "System damaged at " + DateTime.Now,
            Title = DateTime.Now + "System damaged"
        });

        Console.WriteLine("Mechanic dispatched to " + token.System?.Name);
        Thread.Sleep(5000);
        using var scope = ScopeFactory.CreateScope();
        var eventBusClient = scope.ServiceProvider.GetRequiredService<IEventBusClient>();

        var message =
            JsonSerializer.Serialize(new SystemRepairedEvent(EventType.SystemRepaired.ToString(), token.System));
        eventBusClient.Publish(message);
    }

    public async Task Visit(SystemRepairedEvent token) {
        var channel = GrpcChannel.ForAddress("http://localhost:5151");
        Crew.Crew.CrewClient client = new Crew.Crew.CrewClient(channel);
        client.CreateLogbookEntry(new LogbookEntryRequest() {
            AuthorId = 1,
            Content = "System repaired at " + DateTime.Now,
            Title = DateTime.Now + "System repaired"
        });
    }

    public async Task Visit(IntrudersDetectedEvent token) {
        Console.WriteLine("Send Guards");
        using var scope = ScopeFactory.CreateScope();
    }
}