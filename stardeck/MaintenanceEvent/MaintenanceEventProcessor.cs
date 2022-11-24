using EventBusConnection.Event;
using MaintenanceEvent.EventHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace MaintenanceEvent;

public class MaintenanceEventProcessor : AEventProcessor {
    public MaintenanceEventProcessor(IServiceScopeFactory scopeFactory) : base(scopeFactory) {
        this["ARRIVED_AT_LOCATION"] = new ArrivedAtLocationEventHandler();
        this["DEPARTED_FROM_LOCATION"] = new DepartedFromLocationEventHandler();
        this["SYSTEM_REPAIRED"] = new SystemRepairedEventHandler();
    }
}