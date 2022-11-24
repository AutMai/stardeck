namespace CrewDatatransfer.Controller.Read;

public record CommanderDto(
    int CrewMemberId,
    int Health
) : ACrewDto(CrewMemberId, Health);