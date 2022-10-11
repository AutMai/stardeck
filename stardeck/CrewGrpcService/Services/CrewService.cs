using Crew;
using Grpc.Core;
using CrewGrpcService.Datastore;
using Google.Protobuf.WellKnownTypes;

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

    public override async Task ReadLogbook(Empty request, IServerStreamWriter<LogbookReply> responseStream, ServerCallContext context) {
        foreach (var logbook in CrewDatastore.Logbook) {
            await responseStream.WriteAsync(logbook.ToLogbookReply());
        }
    }

    public override Task<LogbookReply> ReadSingleEntryLogbook(SingleLogbookEntryRequest request,
        ServerCallContext context) {
        var x = CrewDatastore.Logbook.SingleOrDefault(l => l.LogId == request.Id);
        return Task.FromResult(x.ToLogbookReply());
    }
}