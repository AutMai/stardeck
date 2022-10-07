namespace MaintenanceDTO.Read;

public record GravitationSystemDTO(
    int SystemId,
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
);