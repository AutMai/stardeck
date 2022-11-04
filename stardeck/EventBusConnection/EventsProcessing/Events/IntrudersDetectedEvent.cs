namespace EventBusConnection.EventsProcessing.Events;

public class IntrudersDetectedEvent : BaseEvent
{
    public IntrudersDetectedEvent()
    {
        
    }
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}