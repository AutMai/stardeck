using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NavigationDomain.Repositories.Interfaces;
using NavigationModel.Configurations;
using NavigationModel.Entities;


namespace NavigationDomain.Repositories.Implementations;

public class GalaxyRepository : ARepository<Galaxy> {
    public GalaxyRepository(NavigationContext context) : base(context) {
    }
}