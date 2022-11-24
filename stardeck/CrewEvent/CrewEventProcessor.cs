using EventBusConnection.Events;
using Microsoft.Extensions.DependencyInjection;

namespace CrewEvent; 

public class CrewEventProcessor : AEventProcessor {
    public CrewEventProcessor(IServiceScopeFactory scopeFactory) : base(scopeFactory) {
        
    }
}