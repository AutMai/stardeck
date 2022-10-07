namespace CrewDTOs.Create;

public record CreateDroidDto
(
    int Health
) : ACreateCrewDto(Health);