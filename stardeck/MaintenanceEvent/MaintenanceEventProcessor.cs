using EventBusConnection.Event;
using MaintenanceEvent.EventHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace MaintenanceEvent;

public class MaintenanceEventProcessor : AEventProcessor {
    public MaintenanceEventProcessor(IServiceScopeFactory scopeFactory) : base(scopeFactory) {
        this["ARRIVED_AT_LOCATION"] = new ArrivedAtLocationEventHandler();
        this["DEPARTED_FROM_LOCATION"] = new DepartedFromLocationEventHandler();
        this["SYSTEM_REPAIRED"] = new SystemRepairedEventHandler();
        this["STOCKTAKING"] = new StocktakingEventHandler();
        this["REFILL_INVENTORY"] = new RefillInventoryEventHandler();
        this["LACK_OF_ITEM"] = new LackOfItemEventHandler();
        this["CREW_MEMBER_CRITICAL_HEALTH"] = new CrewMemberCriticalHealthEventHandler();
    }
}