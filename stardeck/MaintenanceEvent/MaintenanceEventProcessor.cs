using EventBusConnection.Events;
using Microsoft.Extensions.DependencyInjection;

namespace MaintenanceEvent;

public class MaintenanceEventProcessor : AEventProcessor {
    public MaintenanceEventProcessor(IServiceScopeFactory scopeFactory) : base(scopeFactory) {
    }
}