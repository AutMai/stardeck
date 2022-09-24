using System.Linq.Expressions;
using CrewDomain.Repositories.Interfaces;
using CrewModel.Configurations;
using CrewModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrewDomain.Repositories.Implementations;

public class LogbookRepository : ARepository<Logbook> {
    public LogbookRepository(CrewContext context) : base(context) {
    }
}