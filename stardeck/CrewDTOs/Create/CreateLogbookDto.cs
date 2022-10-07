using CrewDTOs.Read;

namespace CrewDTOs.Create;

public record CreateLogbookDto(
    string Title,
    string Content,
    int AuthorMemberId,
    ACrewDto AuthorMember
);