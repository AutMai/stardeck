using MaintenanceDatatransfer.Controller.Read;

namespace MaintenanceDatatransfer.Controller.Create;

public abstract record CreateASystemDTO(
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
);