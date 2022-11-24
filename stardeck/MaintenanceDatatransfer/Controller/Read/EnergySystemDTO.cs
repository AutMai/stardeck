namespace MaintenanceDatatransfer.Controller.Read;

public record EnergySystemDTO(
    int SystemId,
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
) : ASystemDTO(SystemId, Name, Status, ShipId, Ship);