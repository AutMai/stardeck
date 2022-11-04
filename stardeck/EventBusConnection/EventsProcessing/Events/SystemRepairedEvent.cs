using CrewDTOs.Read;
using MaintenanceDTO.Read;

namespace EventBusConnection.EventsProcessing.Events;

public class SystemRepairedEvent : BaseEvent {
    public ASystemDTO System { get; set; }


    public SystemRepairedEvent() {
        
    }


    public override void Accept(IVisitor visitor) {
        visitor.Visit(this);
    }

    public SystemRepairedEvent(string type, ASystemDTO system) : base(type) {
        System = system;
    }
}