namespace MaintenanceDTO.Create;

public record EnergySystemDTO(
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
);