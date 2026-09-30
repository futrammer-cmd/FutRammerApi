namespace FutRammerApi.Domain.Academics;

/// <summary>
/// الفصل/الموسم الدراسي - جدول Seasons داخل سكيما Academics.
/// يحتوي على الحقول الافتراضية العامة (Base Columns) المتفق عليها لكل جداول Academics،
/// بالإضافة إلى الحقول الخاصة بالفصل الدراسي نفسه.
/// </summary>
public class Season : BaseEntity<long>, IAggregateRoot
{
    // بيانات الفصل الدراسي الأساسية
    public string SeasonCode { get; set; } = default!;
    public string SeasonNameAra { get; set; } = default!;
    public string SeasonNameEng { get; set; } = default!;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    // ================= الحقول الافتراضية العامة (تتكرر في كل جداول سكيما Academics) =================
    public bool NotActive { get; set; }
    public bool FlgDelete { get; set; }
    public string? Notes { get; set; }
    public string? AddBy { get; set; }
    public DateTime AddTime { get; set; } = DateTime.UtcNow;
    public string? EditBy { get; set; }
    public DateTime? EditTime { get; set; }
    public long? MenuId { get; set; }
    public string? Icon { get; set; }
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;
    public string? CreatorUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public string? LastModifierUserId { get; set; }
    public DateTime? DeletionTime { get; set; }
    public string? DeleterUserId { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public bool IsBlocked { get; set; }
    public bool IsSystem { get; set; }
    public bool IsImported { get; set; }
    public string? DescriptionAra { get; set; }
    public string? DescriptionEng { get; set; }
    public string? Attachment { get; set; }
    public bool IsSynchronized { get; set; }
    public DateTime? SynchronizationDate { get; set; }
    public string? GLSerial { get; set; }
    public string? GLType { get; set; }
    public bool PostedToGL { get; set; }
    public string? ConfirmerUserId { get; set; }
    public bool Confirmed { get; set; }
    public bool IsLinkWithTaxAuthority { get; set; }
    public DateTime? ConfirmationTime { get; set; }
    public string? GeneralTrxSerial { get; set; }
    public string? MonthlyTrxSerial { get; set; }
    public string? AttachmentName { get; set; }
    public bool IsBlackList { get; set; }
    public long? MasterID { get; set; }
    public long? PrintCount { get; set; }
    public bool IsFavorite { get; set; }
    // ====================================================================================

    public Season(string seasonCode, string seasonNameAra, string seasonNameEng, DateTime? startDate, DateTime? endDate, string? descriptionAra, string? descriptionEng)
    {
        SeasonCode = seasonCode;
        SeasonNameAra = seasonNameAra;
        SeasonNameEng = seasonNameEng;
        StartDate = startDate;
        EndDate = endDate;
        DescriptionAra = descriptionAra;
        DescriptionEng = descriptionEng;
        IsActive = true;
    }

    public Season Update(
        string? seasonCode,
        string? seasonNameAra,
        string? seasonNameEng,
        DateTime? startDate,
        DateTime? endDate,
        string? descriptionAra,
        string? descriptionEng,
        string? notes,
        string? attachment,
        bool? isActive)
    {
        if (seasonCode is not null && SeasonCode?.Equals(seasonCode) is not true) SeasonCode = seasonCode;
        if (seasonNameAra is not null && SeasonNameAra?.Equals(seasonNameAra) is not true) SeasonNameAra = seasonNameAra;
        if (seasonNameEng is not null && SeasonNameEng?.Equals(seasonNameEng) is not true) SeasonNameEng = seasonNameEng;
        if (startDate is not null) StartDate = startDate;
        if (endDate is not null) EndDate = endDate;
        if (descriptionAra is not null) DescriptionAra = descriptionAra;
        if (descriptionEng is not null) DescriptionEng = descriptionEng;
        if (notes is not null) Notes = notes;
        if (attachment is not null) Attachment = attachment;
        if (isActive is not null) IsActive = isActive.Value;
        return this;
    }
}
