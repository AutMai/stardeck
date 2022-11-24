using Crew;
using Grpc.Core;
using CrewGrpcService.Datastore;
using CrewModel.Entities;
using Google.Protobuf.WellKnownTypes;
using Type = System.Type;

namespace CrewGrpcService.Services;

public class CrewService : Crew.Crew.CrewBase {
    private readonly ILogger<CrewService> _logger;

    public CrewService(ILogger<CrewService> logger) {
        _logger = logger;
    }

    public override Task<CrewReplies> ReadCrew(Empty request, ServerCallContext context) {
        var crewReplies = new CrewReplies();
        crewReplies.Crew.AddRange(CrewDatastore.Crew.Select(c => c.ToCrewReply()));
        return Task.FromResult(crewReplies);
    }

    public override Task<CrewReply> ReadSingleCrewMember(SingleCrewMemberRequest request, ServerCallContext context) {
        var x = CrewDatastore.Crew.SingleOrDefault(c => c.CrewMemberId == request.CrewMemberId);
        return Task.FromResult(x.ToCrewReply());
    }

    public override async Task ReadLogbook(Empty request, IServerStreamWriter<LogbookReply> responseStream,
        ServerCallContext context) {
        foreach (var logbook in CrewDatastore.Logbook) {
            await responseStream.WriteAsync(logbook.ToLogbookReply());
        }
    }

    public override Task<LogbookReply> ReadSingleEntryLogbook(SingleLogbookEntryRequest request,
        ServerCallContext context) {
        var x = CrewDatastore.Logbook.SingleOrDefault(l => l.LogId == request.Id);
        return Task.FromResult(x.ToLogbookReply());
    }

    public override Task<LogbookReply> CreateLogbookEntry(LogbookEntryRequest request, ServerCallContext context) {
        var id = CrewDatastore.Logbook.Max(l => l.LogId) + 1;
        Logbook l;
        CrewDatastore.Logbook.Add(l = new Logbook() {
            LogId = id,
            Content = request.Content,
            Title = request.Title,
            AuthorMember = CrewDatastore.Crew.SingleOrDefault(am => am.CrewMemberId == request.AuthorId),
            AuthorMemberId = request.AuthorId
        });

        return Task.FromResult(l.ToLogbookReply());
    }

    public override Task<CrewReply> CreateCrew(CreateCrewRequest request, ServerCallContext context) {
        var id = CrewDatastore.Crew.Max(c => c.CrewMemberId) + 1;
        var t = Type.GetType(request.Role.ToString());
        var c = Activator.CreateInstance(t) as CrewModel.Entities.Crew;
        
        c.Health = request.Health;
        c.CrewMemberId = id;
        
        CrewDatastore.Crew.Add(c);

        return Task.FromResult(c.ToCrewReply());
    }

    public override Task<CrewReply> UpdateCrew(UpdateCrewRequest request, ServerCallContext context) {
        var cm = CrewDatastore.Crew.SingleOrDefault(c => c.CrewMemberId == request.CrewMemberId);
        cm.Health = request.Health;
        return Task.FromResult(cm.ToCrewReply());
    }
}