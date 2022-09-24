using System;
using System.Collections.Generic;

namespace NavigationModel.Entities
{
    public partial class Route
    {
        public int RouteId { get; set; }
        public decimal Length { get; set; }
        public int FlightTime { get; set; }
        public decimal FuelCost { get; set; }
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }
        public sbyte IsHypergate { get; set; }

        public virtual Location FromLocation { get; set; } = null!;
        public virtual Location ToLocation { get; set; } = null!;
    }
}
