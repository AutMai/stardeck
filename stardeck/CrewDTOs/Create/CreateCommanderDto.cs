namespace CrewDTOs.Create;

public record CreateCommanderDto(
    int Health
) : ACreateCrewDto(Health);