using CrewDatatransfer.Controller.Read;

namespace CrewDatatransfer.Controller.Create;

public record CreateLogbookDto(
    string Title,
    string Content,
    int AuthorMemberId,
    ACrewDto AuthorMember
);