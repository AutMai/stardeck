namespace MaintenanceDTO.Create;

public record InventoryDTO(
    string Name,
    int Amount,
    int RoomId,
    RoomDTO Room
);