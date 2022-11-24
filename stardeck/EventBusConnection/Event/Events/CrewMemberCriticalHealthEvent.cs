namespace EventBusConnection.Event.Events; 

public record CrewMemberCriticalHealthEvent(List<int> crewMemberIds) : EventRecord("CREW_MEMBER_CRITICAL_HEALTH");