namespace FutRammerApi.Application.Academics.Teachers;

public class UpdateTeacherRequest : IRequest<long>
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
    public bool? IsActive { get; set; }
}

public class UpdateTeacherRequestValidator : CustomValidator<UpdateTeacherRequest>
{
    public UpdateTeacherRequestValidator(IRepository<Teacher> repository, IStringLocalizer<UpdateTeacherRequestValidator> T)
    {
        RuleFor(p => p.TeacherCode)
            .NotEmpty()
            .MaximumLength(50)
            .MustAsync(async (teacher, code, ct) =>
                    await repository.FirstOrDefaultAsync(new TeacherByCodeSpec(code), ct)
                        is not Teacher existingTeacher || existingTeacher.Id == teacher.Id)
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

public class UpdateTeacherRequestHandler : IRequestHandler<UpdateTeacherRequest, long>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Teacher> _repository;
    private readonly IStringLocalizer _t;

    public UpdateTeacherRequestHandler(IRepositoryWithEvents<Teacher> repository, IStringLocalizer<UpdateTeacherRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<long> Handle(UpdateTeacherRequest request, CancellationToken cancellationToken)
    {
        var teacher = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = teacher
        ?? throw new NotFoundException(_t["Teacher {0} Not Found.", request.Id]);

        teacher.Update(
            request.TeacherCode,
            request.TeacherNameAra,
            request.TeacherNameEng,
            request.Email,
            request.Phone,
            request.DescriptionAra,
            request.DescriptionEng,
            request.Notes,
            request.Attachment,
            request.IsActive);

        await _repository.UpdateAsync(teacher, cancellationToken);

        return request.Id;
    }
}
