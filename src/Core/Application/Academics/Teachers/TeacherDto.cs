namespace FutRammerApi.Application.Academics.Teachers;

public class TeacherDto : IDto
{
    public long Id { get; set; }
    public string TeacherCode { get; set; } = default!;
    public string TeacherNameAra { get; set; } = default!;
    public string TeacherNameEng { get; set; } = default!;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? DescriptionAra { get; set; }
    public string? DescriptionEng { get; set; }
    public string? Notes { get; set; }
    public string? Attachment { get; set; }
    public bool IsActive { get; set; }
}
