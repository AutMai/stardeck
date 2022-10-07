namespace CrewDTOs.Create;

public record CreateGuardDto
(
    int Health
) : ACreateCrewDto(Health);