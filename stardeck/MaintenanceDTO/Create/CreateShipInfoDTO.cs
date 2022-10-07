namespace MaintenanceDTO.Create;

public record ShipInfoDTO(
    string Name,
    string CurrentLocation,
    HashSet<ASystemDTO> System,
    HashSet<Read.RoomDTO> Room
);