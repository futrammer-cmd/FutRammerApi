namespace FutRammerApi.Domain.Academics;

/// <summary>
/// المادة التعليمية (الدرس) - جدول Lessons داخل سكيما Academics.
/// كل Lesson مرتبط بموسم دراسي (Season) واحد عبر SeasonId.
/// يحتوي على الحقول الافتراضية العامة (Base Columns) المتفق عليها لكل جداول Academics،
/// بالإضافة إلى الحقول الخاصة بالمادة التعليمية نفسها.
/// </summary>
public class Lesson : BaseEntity<long>, IAggregateRoot
{
    // بيانات المادة التعليمية الأساسية
    public string LessonCode { get; set; } = default!;
    public string LessonNameAra { get; set; } = default!;
    public string LessonNameEng { get; set; } = default!;
    public long SeasonId { get; set; }
    public Season? Season { get; set; }

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

    public Lesson(string lessonCode, string lessonNameAra, string lessonNameEng, long seasonId, string? descriptionAra, string? descriptionEng)
    {
        LessonCode = lessonCode;
        LessonNameAra = lessonNameAra;
        LessonNameEng = lessonNameEng;
        SeasonId = seasonId;
        DescriptionAra = descriptionAra;
        DescriptionEng = descriptionEng;
        IsActive = true;
    }

    public Lesson Update(
        string? lessonCode,
        string? lessonNameAra,
        string? lessonNameEng,
        long? seasonId,
        string? descriptionAra,
        string? descriptionEng,
        string? notes,
        string? attachment,
        bool? isActive)
    {
        if (lessonCode is not null && LessonCode?.Equals(lessonCode) is not true) LessonCode = lessonCode;
        if (lessonNameAra is not null && LessonNameAra?.Equals(lessonNameAra) is not true) LessonNameAra = lessonNameAra;
        if (lessonNameEng is not null && LessonNameEng?.Equals(lessonNameEng) is not true) LessonNameEng = lessonNameEng;
        if (seasonId is not null) SeasonId = seasonId.Value;
        if (descriptionAra is not null) DescriptionAra = descriptionAra;
        if (descriptionEng is not null) DescriptionEng = descriptionEng;
        if (notes is not null) Notes = notes;
        if (attachment is not null) Attachment = attachment;
        if (isActive is not null) IsActive = isActive.Value;
        return this;
    }
}
