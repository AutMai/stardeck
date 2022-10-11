using MaintenanceDTO.Read;

namespace MaintenanceDTO.Create;

public abstract record CreateASystemDTO(
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
);