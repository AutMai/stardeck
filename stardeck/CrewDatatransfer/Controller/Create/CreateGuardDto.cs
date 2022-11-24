namespace CrewDatatransfer.Controller.Create;

public record CreateGuardDto
(
    int Health
) : ACreateCrewDto(Health);