using MaintenanceDatatransfer.Controller.Read;

namespace MaintenanceDatatransfer.Controller.Create;

public record CreateRoomDTO(
    string Name,
    int ShipId,
    ShipInfoDTO Ship,
    HashSet<InventoryDTO> Inventory);