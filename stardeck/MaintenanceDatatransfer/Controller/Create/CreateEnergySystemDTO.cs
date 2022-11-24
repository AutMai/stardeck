using MaintenanceDatatransfer.Controller.Read;

namespace MaintenanceDatatransfer.Controller.Create;

public record CreateEnergySystemDTO(
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
):  CreateASystemDTO(Name, Status, ShipId, Ship);