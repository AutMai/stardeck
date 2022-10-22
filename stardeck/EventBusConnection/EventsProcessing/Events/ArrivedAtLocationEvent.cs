namespace EventBusConnection.EventsProcessing.Events;

public class ArrivedAtLocationEvent : BaseEvent {
    public string Location { get; set; }


    public ArrivedAtLocationEvent() {
        
    }


    public override void Accept(IVisitor visitor) {
        visitor.Visit(this);
    }

    public ArrivedAtLocationEvent(string type, string location) : base(type) {
        Location = location;
    }
}