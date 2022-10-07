namespace CrewDTOs.Read;

public record MechanicDto(
    int CrewMemberId, 
    int Health
): ACrewDto(CrewMemberId, Health);