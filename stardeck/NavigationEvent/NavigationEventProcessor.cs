using EventBusConnection.Event;
using Microsoft.Extensions.DependencyInjection;
using NavigationEvent.EventHandlers;

namespace NavigationEvent;

public class NavigationEventProcessor : AEventProcessor {
    public NavigationEventProcessor(IServiceScopeFactory scopeFactory) : base(scopeFactory) {
        this["TRAVEL_TO"] = new TravelToEventHandler();
    }
}