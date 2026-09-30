namespace FutRammerApi.Application.Academics.Teachers;

public class CreateTeacherRequest : IRequest<long>
{
    public string TeacherCode { get; set; } = default!;
    public string TeacherNameAra { get; set; } = default!;
    public string TeacherNameEng { get; set; } = default!;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? DescriptionAra { get; set; }
    public string? DescriptionEng { get; set; }
    public string? Attachment { get; set; }
}

public class CreateTeacherRequestValidator : CustomValidator<CreateTeacherRequest>
{
    public CreateTeacherRequestValidator(IReadRepository<Teacher> repository, IStringLocalizer<CreateTeacherRequestValidator> T)
    {
        RuleFor(p => p.TeacherCode)
            .NotEmpty()
            .MaximumLength(50)
            .MustAsync(async (code, ct) => await repository.FirstOrDefaultAsync(new TeacherByCodeSpec(code), ct) is null)
                .WithMessage((_, code) => T["Teacher Code {0} already Exists.", code]);

        RuleFor(p => p.TeacherNameAra)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(p => p.TeacherNameEng)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(p => p.Email)
            .EmailAddress()
            .When(p => !string.IsNullOrWhiteSpace(p.Email));
    }
}

public class CreateTeacherRequestHandler : IRequestHandler<CreateTeacherRequest, long>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Teacher> _repository;

    public CreateTeacherRequestHandler(IRepositoryWithEvents<Teacher> repository) => _repository = repository;

    public async Task<long> Handle(CreateTeacherRequest request, CancellationToken cancellationToken)
    {
        var teacher = new Teacher(
            request.TeacherCode,
            request.TeacherNameAra,
            request.TeacherNameEng,
            request.Email,
            request.Phone,
            request.DescriptionAra,
            request.DescriptionEng)
        {
            Attachment = request.Attachment
        };

        await _repository.AddAsync(teacher, cancellationToken);

        return teacher.Id;
    }
}
