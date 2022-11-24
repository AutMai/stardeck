namespace EventBusConnection.Event.Events; 

public record HealCrewMemberEvent(List<int> crewMemberIds) : EventRecord("HEAL_CREW_MEMBER");