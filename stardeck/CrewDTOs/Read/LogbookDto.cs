namespace CrewDTOs.Read;

public record LogbookDto(
    int LogId,
    string Title,
    string Content,
    int AuthorId,
    ACrewDto Author
);