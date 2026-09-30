namespace FutRammerApi.Application.Identity.Users;

public class CreateUserRequest
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
    public string? PhoneNumber { get; set; }

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