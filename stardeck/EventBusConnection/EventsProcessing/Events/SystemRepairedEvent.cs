namespace EventBusConnection.EventsProcessing.Events;

public class SystemDamagedEvent : BaseEvent {
    public string Location { get; set; }


    public SystemDamagedEvent() {
        
    }


    public override void Accept(IVisitor visitor) {
        visitor.Visit(this);
    }

    public SystemDamagedEvent(string type, string location) : base(type) {
        Location = location;
    }
}