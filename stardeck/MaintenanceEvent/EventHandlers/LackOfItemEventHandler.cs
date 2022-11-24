using System.Text.Json;
using EventBusConnection.Client;
using EventBusConnection.Event;
using EventBusConnection.Event.Events;
using Microsoft.Extensions.DependencyInjection;

namespace MaintenanceEvent.EventHandlers;

public class LackOfItemEventHandler : IEventHandler
{
    public Task Execute(IServiceScopeFactory serviceScopeFactory, string eventMessage)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var eventPublisher = scope.ServiceProvider.GetRequiredService<IEventPublisher>();
        
        eventPublisher.Publish(JsonSerializer.Serialize(new StocktakingEvent()));
        return Task.CompletedTask;
    }
}