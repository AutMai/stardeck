using NavigationDTOs.Read;

namespace NavigationDTOs.Create;

public record CreateGalaxyDto(
    string Name,
    decimal CoordX,
    decimal CoordY,
    decimal CoordZ,
    HashSet<PlanetDto> Planets
) : CreateLocationDto(Name, CoordX, CoordY, CoordZ);