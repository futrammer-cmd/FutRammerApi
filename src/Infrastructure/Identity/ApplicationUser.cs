using Microsoft.AspNetCore.Identity;

namespace FutRammerApi.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

    public string? ObjectId { get; set; }

    // Student profile fields collected during registration.
    public string? ProgramLanguage { get; set; }
    public string? Gender { get; set; }
    public string? MiddleName { get; set; }
    public string? Nationality { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? MaritalStatus { get; set; }
    public string? MotherTongue { get; set; }
    public string? EducationLevel { get; set; }
    public string? Major { get; set; }
    public string? CurrentJob { get; set; }
    public int? GraduationYear { get; set; }
    public bool NotifyConsent { get; set; } = true;
}