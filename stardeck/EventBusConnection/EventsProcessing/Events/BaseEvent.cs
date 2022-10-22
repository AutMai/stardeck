namespace EventBusConnection.EventsProcessing.Events; 

public abstract class BaseEvent {
    public string Type { get; set; }

    public BaseEvent() {
        
    }
    protected BaseEvent(string type) {
        Type = type;
    }
    public abstract void Accept(IVisitor visitor);
}