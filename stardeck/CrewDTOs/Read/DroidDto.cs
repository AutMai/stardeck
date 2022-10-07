namespace CrewDTOs.Read;

public record DroidDto
(
    int CrewMemberId, 
    int Health
) : ACrewDto(CrewMemberId, Health);