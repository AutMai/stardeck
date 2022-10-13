using MaintenanceDTO.Read;

namespace MaintenanceDTO.Create;

public record CreateShipInfoDTO(
    string Name,
    string CurrentLocation,
    HashSet<ASystemDTO> System,
    HashSet<RoomDTO> Room
);