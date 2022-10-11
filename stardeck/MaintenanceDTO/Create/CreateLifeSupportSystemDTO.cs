using MaintenanceDTO.Read;

namespace MaintenanceDTO.Create;

public record CreateLifeSupportSystemDTO(
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
) : CreateASystemDTO(Name, Status, ShipId, Ship);