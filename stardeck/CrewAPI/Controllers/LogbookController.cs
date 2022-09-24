using CrewDomain.Repositories.Interfaces;
using CrewModel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrewAPI.Controllers;

[ApiController]
[Route("/logbook")]
public class LogbookController : AController<Logbook> {
    public LogbookController(IRepository<Logbook> repo) : base(repo) {
    }
}