using System.Text.Json;
using Crew;
using CrewModel.Entities;
using EventBusConnection.Event;
using EventBusConnection.Event.Events;
using Grpc.Net.Client;
using MaintenanceDomain.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CrewEvent.Eventhandlers;

public class LogEventHandler : IEventHandler {
    public Task Execute(IServiceScopeFactory serviceScopeFactory, string eventMessage) {
        var e = JsonSerializer.Deserialize<LogEvent>(eventMessage);
        
        var channel = GrpcChannel.ForAddress("http://localhost:5151");
        var client = new Crew.Crew.CrewClient(channel);

        client.CreateLogbookEntry(new LogbookEntryRequest() {
            Title = e.title,
            Content = e.content,
            AuthorId = e.author
        });
        
        return Task.CompletedTask;
    }
}