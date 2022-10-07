namespace MaintenanceDTO.Read;

public record EnergySystemDTO(
    int SystemId,
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
);