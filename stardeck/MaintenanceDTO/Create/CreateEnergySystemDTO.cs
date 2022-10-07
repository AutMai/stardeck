namespace MaintenanceDTO.Create;

public record EnergySystemDTO(
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
):  ASystemDTO(Name, Status, ShipId, Ship);