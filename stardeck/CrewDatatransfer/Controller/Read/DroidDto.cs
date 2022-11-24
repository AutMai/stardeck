namespace CrewDatatransfer.Controller.Read;

public record DroidDto
(
    int CrewMemberId, 
    int Health
) : ACrewDto(CrewMemberId, Health);