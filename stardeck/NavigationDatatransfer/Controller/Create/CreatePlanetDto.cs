using NavigationDatatransfer.Controller.Read;

namespace NavigationDatatransfer.Controller.Create;

public record CreatePlanetDto(
    string Name,
    decimal CoordX,
    decimal CoordY,
    decimal CoordZ,
    sbyte IsExoplanet,
    GalaxyDto Galaxy
) : CreateLocationDto(Name, CoordX, CoordY, CoordZ);
