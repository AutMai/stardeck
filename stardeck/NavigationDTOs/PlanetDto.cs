namespace NavigationDTOs;

public record PlanetDto(
    int LocationId,
    string Name,
    decimal CoordX,
    decimal CoordY,
    decimal CoordZ,
    sbyte IsExoplanet,
    int GalaxyId,
    GalaxyDto Galaxy
);
