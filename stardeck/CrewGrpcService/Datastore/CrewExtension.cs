using Crew;

namespace CrewGrpcService.Datastore;

public static class CrewExtension {
    public static CrewReply ToCrewReply(this CrewModel.Entities.Crew crew) => new CrewReply() {
        CrewMemberId = crew.CrewMemberId,
        Health = crew.Health,
        Role = crew.GetType().Name
    };
    
    public static LogbookReply ToLogbookReply(this CrewModel.Entities.Logbook logbook) => new LogbookReply() {
        LogId = logbook.LogId,
        Author = logbook.AuthorMember.ToCrewReply(),
        AuthorId = logbook.AuthorMemberId,
        Content = logbook.Content,
        Title = logbook.Title
    };
}