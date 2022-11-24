namespace MaintenanceDatatransfer.Controller.Read;

public record GravitationSystemDTO(
    int SystemId,
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
) : ASystemDTO(SystemId, Name, Status, ShipId, Ship);