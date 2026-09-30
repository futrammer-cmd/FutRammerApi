namespace FutRammerApi.Application.Academics.Lessons;

public class LessonDto : IDto
{
    public long Id { get; set; }
    public string LessonCode { get; set; } = default!;
    public string LessonNameAra { get; set; } = default!;
    public string LessonNameEng { get; set; } = default!;
    public long SeasonId { get; set; }
    public string? SeasonNameAra { get; set; }
    public string? SeasonNameEng { get; set; }
    public string? DescriptionAra { get; set; }
    public string? DescriptionEng { get; set; }
    public string? Notes { get; set; }
    public string? Attachment { get; set; }
    public bool IsActive { get; set; }
}
