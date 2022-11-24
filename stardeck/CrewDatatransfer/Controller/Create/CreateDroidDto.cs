namespace CrewDatatransfer.Controller.Create;

public record CreateDroidDto
(
    int Health
) : ACreateCrewDto(Health);