namespace NavigationDTOs;

public record RouteDto
(
    int RouteId,
    decimal Length,
    int FlightTime,
    decimal FuelCost,
    int FromLocationId,
    int ToLocationId,
    sbyte IsHypergate,
    PlanetDto FromLocation,
    PlanetDto ToLocation
);