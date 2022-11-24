namespace NavigationDatatransfer.Controller.Create;

public abstract record CreateLocationDto(
    string Name,
    decimal CoordX,
    decimal CoordY,
    decimal CoordZ
);