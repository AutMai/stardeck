using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NavigationDomain.Repositories.Interfaces;
using NavigationModel.Configurations;
using NavigationModel.Entities;


namespace NavigationDomain.Repositories.Implementations;

public class RouteRepository : ARepository<Route> {
    public RouteRepository(NavigationContext context) : base(context) {
    }
}