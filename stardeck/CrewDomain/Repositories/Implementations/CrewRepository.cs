using System.Linq.Expressions;
using CrewDomain.Repositories.Interfaces;
using CrewModel.Configurations;
using CrewModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrewDomain.Repositories.Implementations;

public class CrewRepository : ARepository<Crew> {
    public CrewRepository(CrewContext context) : base(context) {
    }
}