namespace CrewDatatransfer.Controller.Create;

public record CreateCommanderDto(
    int Health
) : ACreateCrewDto(Health);