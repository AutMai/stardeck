namespace NavigationDTOs; 

public record GalaxyDto(
    int LocationId,
    string Name,
    decimal CoordX,
    decimal CoordY,
    decimal CoordZ,
    HashSet<PlanetDto> Planets
);