using NavigationDatatransfer.Controller.Read;

namespace NavigationDatatransfer.Controller.Create;

public record CreateGalaxyDto(
    string Name,
    decimal CoordX,
    decimal CoordY,
    decimal CoordZ,
    HashSet<PlanetDto> Planets
) : CreateLocationDto(Name, CoordX, CoordY, CoordZ);