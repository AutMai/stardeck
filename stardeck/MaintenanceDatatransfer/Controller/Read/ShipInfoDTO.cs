namespace MaintenanceDatatransfer.Controller.Read;

public record ShipInfoDTO(
    int ShipId,
    string Name,
    string CurrentLocation,
    HashSet<ASystemDTO> System,
    HashSet<RoomDTO> Room
);