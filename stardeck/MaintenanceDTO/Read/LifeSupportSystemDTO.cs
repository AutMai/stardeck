namespace MaintenanceDTO.Read;

public record LifeSupportSystemDTO(
    int SystemId,
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
) : ASystemDTO(SystemId, Name, Status, ShipId, Ship);