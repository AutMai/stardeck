namespace EventBusConnection.EventsProcessing.Events;

public class DepartedFromLocationEvent : BaseEvent
{
    public string Location { get; set; }

    public DepartedFromLocationEvent()
    {
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public DepartedFromLocationEvent(string type, string location) : base(type)
    {
        Location = location;
    }
}