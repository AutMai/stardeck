namespace CrewDTOs.Create;

public record CreateMechanicDto(
    int Health
) : ACreateCrewDto(Health);