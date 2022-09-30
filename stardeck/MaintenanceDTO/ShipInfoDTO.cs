namespace MaintenanceDTO;

public record ShipInfoDTO(
    int ShipId,
    string Name,
    string CurrentLocation,
    HashSet<SystemDTO> System,
    HashSet<RoomDTO> Room
);