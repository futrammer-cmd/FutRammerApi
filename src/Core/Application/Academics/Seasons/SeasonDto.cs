namespace FutRammerApi.Application.Academics.Seasons;

public class SeasonDto : IDto
{
    public long Id { get; set; }
    public string SeasonCode { get; set; } = default!;
    public string SeasonNameAra { get; set; } = default!;
    public string SeasonNameEng { get; set; } = default!;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? DescriptionAra { get; set; }
    public string? DescriptionEng { get; set; }
    public string? Notes { get; set; }
    public string? Attachment { get; set; }
    public bool IsActive { get; set; }
}
