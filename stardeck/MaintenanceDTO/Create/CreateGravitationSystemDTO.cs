﻿namespace MaintenanceDTO.Create;

public record GravitationSystemDTO(
    string Name,
    string Status,
    int ShipId,
    ShipInfoDTO Ship
);