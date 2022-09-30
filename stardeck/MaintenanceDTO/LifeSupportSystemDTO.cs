namespace MaintenanceDTO;

public record LifeSupportSystemDTO(
    int SystemId,
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
);