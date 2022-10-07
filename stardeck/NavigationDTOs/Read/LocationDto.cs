namespace NavigationDTOs.Read; 

public record LocationDto(
    int LocationId,
    string Name,
    decimal CoordX,
    decimal CoordY,
    decimal CoordZ
);