namespace CrewDatatransfer.Controller.Read;

public record GuardDto
(
    int CrewMemberId,
    int Health
) : ACrewDto(CrewMemberId, Health);