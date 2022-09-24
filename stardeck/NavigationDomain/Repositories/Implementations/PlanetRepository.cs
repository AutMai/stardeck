using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NavigationDomain.Repositories.Interfaces;
using NavigationModel.Configurations;
using NavigationModel.Entities;


namespace NavigationDomain.Repositories.Implementations;

public class PlanetRepository : ARepository<Planet> {
    public PlanetRepository(NavigationContext context) : base(context) {
    }
}