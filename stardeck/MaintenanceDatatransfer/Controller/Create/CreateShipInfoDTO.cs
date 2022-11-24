using MaintenanceDatatransfer.Controller.Read;

namespace MaintenanceDatatransfer.Controller.Create;

public record CreateShipInfoDTO(
    string Name,
    string CurrentLocation,
    HashSet<ASystemDTO> System,
    HashSet<RoomDTO> Room
);