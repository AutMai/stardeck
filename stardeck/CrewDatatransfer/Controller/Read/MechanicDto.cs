namespace CrewDatatransfer.Controller.Read;

public record MechanicDto(
    int CrewMemberId, 
    int Health
): ACrewDto(CrewMemberId, Health);