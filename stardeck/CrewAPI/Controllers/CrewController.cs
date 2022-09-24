using CrewDomain.Repositories.Interfaces;
using CrewModel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrewAPI.Controllers;

[ApiController]
[Route("/crew")]
public class CrewController : AController<Crew> {
    public CrewController(IRepository<Crew> repo) : base(repo) {
    }
}