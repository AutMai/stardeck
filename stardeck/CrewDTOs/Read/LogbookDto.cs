namespace CrewDTOs.Read;

public record LogbookDto(
    int LogId,
    string Title,
    string Content,
    int AuthorMemberId,
    ACrewDto AuthorMember
);