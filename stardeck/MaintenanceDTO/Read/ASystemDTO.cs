namespace MaintenanceDTO.Read;

public record ASystemDTO(
    int SystemId,
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
);