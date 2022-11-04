using MaintenanceDTO.Read;

namespace EventBusConnection.EventsProcessing.Events;

public class SystemDamagedEvent : BaseEvent {
    public ASystemDTO? System { get; set; }


    public SystemDamagedEvent() {
        
    }


    public override void Accept(IVisitor visitor) {
        visitor.Visit(this);
    }

    public SystemDamagedEvent(string type, ASystemDTO? system) : base(type) {
        System = system;
    }
}