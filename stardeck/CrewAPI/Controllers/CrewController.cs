using System.Text.Json;
using Crew;
using CrewDatatransfer.Controller.Read;
using EventBusConnection.Client;
using EventBusConnection.Event.Events;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Enum = System.Enum;

namespace CrewAPI.Controllers;

[ApiController]
[Route("crew")]
public class CrewController : ControllerBase {
    private readonly Crew.Crew.CrewClient _client;
    private readonly IEventPublisher _eventBusClient;

    public CrewController(IEventPublisher eventBusClient) {
        _eventBusClient = eventBusClient;
        var channel = GrpcChannel.ForAddress("https://localhost:7151");
        _client = new Crew.Crew.CrewClient(channel);
    }

    [HttpGet]
    public async Task<ActionResult<List<ACrewDto>>> ReadAsync() {
        var res = _client.ReadCrew(new Empty());
        var x = res.Crew.Select(c =>
            c.Role switch {
                "Droid" => c.Adapt<DroidDto>(),
                "Commander" => c.Adapt<CommanderDto>(),
                "Guard" => c.Adapt<GuardDto>(),
                "Mechanic" => c.Adapt<MechanicDto>(),
                _ => c.Adapt<ACrewDto>()
            }
        ).ToList();
        return Ok(x);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ACrewDto>> ReadAsync(int id) {
        var res = await _client.ReadSingleCrewMemberAsync(new SingleCrewMemberRequest() { CrewMemberId = id });

        if (res is null) return NotFound();

        var x = res.Role switch {
            "Droid" => res.Adapt<DroidDto>(),
            "Commander" => res.Adapt<CommanderDto>(),
            "Guard" => res.Adapt<GuardDto>(),
            "Mechanic" => res.Adapt<MechanicDto>(),
            _ => res.Adapt<ACrewDto>()
        };

        return Ok(x);
    }
    
    [HttpPost("{role}")]
    public async Task<ActionResult<ACrewDto>> CreateAsync(string role) {
        role = role.First().ToString().ToUpper() + role[1..];
        var roleEnum = Enum.Parse<Role>(role);
        
        var res = await _client.CreateCrewAsync(new CreateCrewRequest() {Health = 100, Role = roleEnum});
        return Ok(res);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<ACrewDto>> UpdateAsync(int id, [FromBody] ACrewDto crew) {
        var res = await _client.UpdateCrewAsync(new UpdateCrewRequest() {
            CrewMemberId = id,
            Health = crew.Health,
        });
        return Ok(res);
    }
    
    [HttpPost("/droid/startStocktaking")]
    public async Task<ActionResult> StartStocktakingAsync() {
        var message = JsonSerializer.Serialize(new StocktakingEvent());
        _eventBusClient.Publish(message);
        return Ok();
    }
}