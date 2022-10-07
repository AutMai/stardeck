namespace MaintenanceDTO.Create;

public record RoomDTO(
    string Name,
    int ShipId,
    ShipInfoDTO Ship,
    HashSet<InventoryDTO> Inventory);