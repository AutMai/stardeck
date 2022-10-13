using MaintenanceDTO.Read;

namespace MaintenanceDTO.Create;

public record CreateInventoryDTO(
    string Name,
    int Amount,
    int RoomId,
    RoomDTO Room
);