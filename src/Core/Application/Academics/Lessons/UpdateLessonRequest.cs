namespace FutRammerApi.Application.Academics.Lessons;

public class UpdateLessonRequest : IRequest<long>
{
    public long Id { get; set; }
    public string LessonCode { get; set; } = default!;
    public string LessonNameAra { get; set; } = default!;
    public string LessonNameEng { get; set; } = default!;
    public long SeasonId { get; set; }
    public string? DescriptionAra { get; set; }
    public string? DescriptionEng { get; set; }
    public string? Notes { get; set; }
    public string? Attachment { get; set; }
    public bool? IsActive { get; set; }
}

public class UpdateLessonRequestValidator : CustomValidator<UpdateLessonRequest>
{
    public UpdateLessonRequestValidator(IRepository<Lesson> repository, IReadRepository<Season> seasonRepository, IStringLocalizer<UpdateLessonRequestValidator> T)
    {
        RuleFor(p => p.LessonCode)
            .NotEmpty()
            .MaximumLength(50)
            .MustAsync(async (lesson, code, ct) =>
                    await repository.FirstOrDefaultAsync(new LessonByCodeSpec(code), ct)
                        is not Lesson existingLesson || existingLesson.Id == lesson.Id)
                .WithMessage((_, code) => T["Lesson Code {0} already Exists.", code]);

        RuleFor(p => p.LessonNameAra)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(p => p.LessonNameEng)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(p => p.SeasonId)
            .NotEmpty()
            .MustAsync(async (seasonId, ct) => await seasonRepository.GetByIdAsync(seasonId, ct) is not null)
                .WithMessage((_, seasonId) => T["Season {0} Not Found.", seasonId]);
    }
}

public class UpdateLessonRequestHandler : IRequestHandler<UpdateLessonRequest, long>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Lesson> _repository;
    private readonly IStringLocalizer _t;

    public UpdateLessonRequestHandler(IRepositoryWithEvents<Lesson> repository, IStringLocalizer<UpdateLessonRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<long> Handle(UpdateLessonRequest request, CancellationToken cancellationToken)
    {
        var lesson = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = lesson
        ?? throw new NotFoundException(_t["Lesson {0} Not Found.", request.Id]);

        lesson.Update(
            request.LessonCode,
            request.LessonNameAra,
            request.LessonNameEng,
            request.SeasonId,
            request.DescriptionAra,
            request.DescriptionEng,
            request.Notes,
            request.Attachment,
            request.IsActive);

        await _repository.UpdateAsync(lesson, cancellationToken);

        return request.Id;
    }
}
