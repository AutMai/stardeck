namespace CrewDTOs;

public record LogbookDto(
    int LogId,
    string Title,
    string Content,
    int AuthorMemberId,
    CrewDto AuthorMember
);