using NavigationDatatransfer.Controller.Read;

namespace NavigationDatatransfer.Controller.Create;

public record CreateRouteDto
(
    decimal Length,
    int FlightTime,
    decimal FuelCost,
    int FromLocationId,
    int ToLocationId,
    sbyte IsHypergate,
    LocationDto FromLocation,
    LocationDto ToLocation
);