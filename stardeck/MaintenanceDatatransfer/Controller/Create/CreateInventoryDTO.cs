using MaintenanceDatatransfer.Controller.Read;

namespace MaintenanceDatatransfer.Controller.Create;

public record CreateInventoryDTO(
    string Name,
    int Amount,
    int RoomId,
    RoomDTO Room
);