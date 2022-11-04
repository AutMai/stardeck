namespace EventBusConnection.EventsProcessing.Events;

public class SystemRepairedEvent : BaseEvent {
    public string Location { get; set; }


    public SystemRepairedEvent() {
        
    }


    public override void Accept(IVisitor visitor) {
        visitor.Visit(this);
    }

    public SystemRepairedEvent(string type, string location) : base(type) {
        Location = location;
    }
}