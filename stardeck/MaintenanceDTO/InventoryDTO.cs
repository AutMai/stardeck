namespace MaintenanceDTO;

public record InventoryDTO(
    int RessourceId,
    string Name,
    int Amount,
    int RoomId,
    RoomDTO Room
);