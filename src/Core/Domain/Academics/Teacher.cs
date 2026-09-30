namespace FutRammerApi.Domain.Academics;

/// <summary>
/// المعلم - جدول Teachers داخل سكيما Academics.
/// يحتوي على الحقول الافتراضية العامة (Base Columns) المتفق عليها لكل جداول Academics،
/// بالإضافة إلى الحقول الخاصة بالمعلم نفسه.
/// </summary>
public class Teacher : BaseEntity<long>, IAggregateRoot
{
    // بيانات المعلم الأساسية
    public string TeacherCode { get; set; } = default!;
    public string TeacherNameAra { get; set; } = default!;
    public string TeacherNameEng { get; set; } = default!;
    public string? Email { get; set; }
    public string? Phone { get; set; }

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

    public Teacher(string teacherCode, string teacherNameAra, string teacherNameEng, string? email, string? phone, string? descriptionAra, string? descriptionEng)
    {
        TeacherCode = teacherCode;
        TeacherNameAra = teacherNameAra;
        TeacherNameEng = teacherNameEng;
        Email = email;
        Phone = phone;
        DescriptionAra = descriptionAra;
        DescriptionEng = descriptionEng;
        IsActive = true;
    }

    public Teacher Update(
        string? teacherCode,
        string? teacherNameAra,
        string? teacherNameEng,
        string? email,
        string? phone,
        string? descriptionAra,
        string? descriptionEng,
        string? notes,
        string? attachment,
        bool? isActive)
    {
        if (teacherCode is not null && TeacherCode?.Equals(teacherCode) is not true) TeacherCode = teacherCode;
        if (teacherNameAra is not null && TeacherNameAra?.Equals(teacherNameAra) is not true) TeacherNameAra = teacherNameAra;
        if (teacherNameEng is not null && TeacherNameEng?.Equals(teacherNameEng) is not true) TeacherNameEng = teacherNameEng;
        if (email is not null) Email = email;
        if (phone is not null) Phone = phone;
        if (descriptionAra is not null) DescriptionAra = descriptionAra;
        if (descriptionEng is not null) DescriptionEng = descriptionEng;
        if (notes is not null) Notes = notes;
        if (attachment is not null) Attachment = attachment;
        if (isActive is not null) IsActive = isActive.Value;
        return this;
    }
}
