using Crew;
using CrewDatatransfer.Controller.Read;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace CrewAPI.Controllers;

[ApiController]
[Route("/logbook")]
public class LogbookController : ControllerBase {
    private readonly Crew.Crew.CrewClient _client;

    public LogbookController() {
        var channel = GrpcChannel.ForAddress("https://localhost:7151");
        _client = new Crew.Crew.CrewClient(channel);
    }

    [HttpGet]
    public async Task<ActionResult<List<LogbookDto>>> ReadAsync() {
        var res = _client.ReadLogbook(new Empty()).ResponseStream.ReadAllAsync();
        List<LogbookDto> logbook = new();
        await foreach (var logbookEntry in res) {
            logbook.Add(logbookEntry.Adapt<LogbookDto>());
        }

        return Ok(logbook);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<LogbookDto>> ReadAsync(int id) {
        var res = await _client.ReadSingleEntryLogbookAsync(new SingleLogbookEntryRequest() { Id = id });

        if (res is null) return NotFound();

        ACrewDto crewDto = res.Author.Role switch {
            "Droid" => res.Author.Adapt<DroidDto>(),
            "Commander" => res.Author.Adapt<CommanderDto>(),
            "Guard" => res.Author.Adapt<GuardDto>(),
            "Mechanic" => res.Author.Adapt<MechanicDto>(),
            _ => res.Author.Adapt<ACrewDto>()
        };

        return Ok(new {
            res.Title, res.Content, res.AuthorId, res.LogId,
            Author = crewDto
        }.Adapt<LogbookDto>());
    }
}