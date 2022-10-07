using NavigationDTOs.Read;

namespace NavigationDTOs.Create;

public abstract record CreateLocationDto(
    string Name,
    decimal CoordX,
    decimal CoordY,
    decimal CoordZ
);