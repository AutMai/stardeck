using EventBusConnection.EventsProcessing.Events;
using Microsoft.Extensions.DependencyInjection;

namespace EventBusConnection.EventsProcessing;

public interface IVisitor
{
    IServiceScopeFactory ScopeFactory { get; init; }
    Task Visit(ArrivedAtLocationEvent token);
    Task Visit(DepartedFromLocationEvent token);
    Task Visit(SystemDamagedEvent token);
    Task Visit(SystemRepairedEvent token);
}