namespace CrewDatatransfer.Controller.Create;

public record CreateMechanicDto(
    int Health
) : ACreateCrewDto(Health);