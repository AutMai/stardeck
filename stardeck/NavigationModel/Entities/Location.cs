using System;
using System.Collections.Generic;

namespace NavigationModel.Entities
{
    public partial class Location
    {
        public Location()
        {
            RoutesFromThisLocation = new HashSet<Route>();
            RouteToThisLocation = new HashSet<Route>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; } = null!;
        public decimal CoordX { get; set; }
        public decimal CoordY { get; set; }
        public decimal CoordZ { get; set; }
        public virtual ICollection<Route> RoutesFromThisLocation { get; set; }
        public virtual ICollection<Route> RouteToThisLocation { get; set; }
    }
}
