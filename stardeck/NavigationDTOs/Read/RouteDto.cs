namespace NavigationDTOs.Read;

public record RouteDto
(
    int RouteId,
    decimal Length,
    int FlightTime,
    decimal FuelCost,
    int FromLocationId,
    int ToLocationId,
    sbyte IsHypergate,
    LocationDto FromLocation,
    LocationDto ToLocation
);