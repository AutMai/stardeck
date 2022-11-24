using Microsoft.Extensions.DependencyInjection;

namespace EventBusConnection.Event; 

public interface IEventHandler {
    Task Execute(IServiceScopeFactory serviceScopeFactory, string eventMessage);
}