namespace MaintenanceDTO;

public record RoomDTO(
    int RoomId,
    string Name,
    int ShipId,
    ShipInfoDTO Ship,
    HashSet<InventoryDTO> Inventory);