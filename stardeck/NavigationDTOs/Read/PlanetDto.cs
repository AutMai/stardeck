namespace NavigationDTOs.Read;

public record PlanetDto(
    int LocationId,
    string Name,
    decimal CoordX,
    decimal CoordY,
    decimal CoordZ,
    sbyte IsExoplanet,
    GalaxyDto Galaxy
) : LocationDto(LocationId, Name, CoordX, CoordY, CoordZ);