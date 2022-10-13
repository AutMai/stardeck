using MaintenanceDTO.Read;

namespace MaintenanceDTO.Create;

public record CreateRoomDTO(
    string Name,
    int ShipId,
    ShipInfoDTO Ship,
    HashSet<InventoryDTO> Inventory);