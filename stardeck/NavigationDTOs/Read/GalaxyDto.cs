namespace NavigationDTOs.Read;

public record GalaxyDto(
        int LocationId,
        string Name,
        decimal CoordX,
        decimal CoordY,
        decimal CoordZ,
        HashSet<PlanetDto> Planets
    )
    : LocationDto(LocationId, Name, CoordX, CoordY, CoordZ);