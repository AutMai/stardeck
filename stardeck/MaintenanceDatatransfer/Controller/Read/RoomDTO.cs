namespace MaintenanceDatatransfer.Controller.Read;

public record RoomDTO(
    int RoomId,
    string Name,
    int ShipId,
    ShipInfoDTO Ship,
    HashSet<InventoryDTO> Inventory);