namespace MaintenanceDTO.Create;

public record LifeSupportSystemDTO(
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
) : ASystemDTO(Name, Status, ShipId, Ship);