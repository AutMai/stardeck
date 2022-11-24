using EventBusConnection.Events;
using Microsoft.Extensions.DependencyInjection;

namespace NavigationEvent;

public class NavigationEventProcessor : AEventProcessor {
    public NavigationEventProcessor(IServiceScopeFactory scopeFactory) : base(scopeFactory) {
    }
}