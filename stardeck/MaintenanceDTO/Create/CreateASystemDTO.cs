namespace MaintenanceDTO.Create;

public abstract record ASystemDTO(
    string Name,
    string Status,
    int ShipId,
    Read.ShipInfoDTO Ship
);

