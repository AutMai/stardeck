﻿namespace MaintenanceDatatransfer.Controller.Read;

public record InventoryDTO(
    int RessourceId,
    string Name,
    int Amount,
    int RoomId,
    RoomDTO Room
);