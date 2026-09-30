namespace FutRammerApi.Application.Academics.Lessons;

public class CreateLessonRequest : IRequest<long>
{
    public string LessonCode { get; set; } = default!;
    public string LessonNameAra { get; set; } = default!;
    public string LessonNameEng { get; set; } = default!;
    public long SeasonId { get; set; }
    public string? DescriptionAra { get; set; }
    public string? DescriptionEng { get; set; }
    public string? Attachment { get; set; }
}

public class CreateLessonRequestValidator : CustomValidator<CreateLessonRequest>
{
    public CreateLessonRequestValidator(IReadRepository<Lesson> repository, IReadRepository<Season> seasonRepository, IStringLocalizer<CreateLessonRequestValidator> T)
    {
        RuleFor(p => p.LessonCode)
            .NotEmpty()
            .MaximumLength(50)
            .MustAsync(async (code, ct) => await repository.FirstOrDefaultAsync(new LessonByCodeSpec(code), ct) is null)
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

public class CreateLessonRequestHandler : IRequestHandler<CreateLessonRequest, long>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Lesson> _repository;

    public CreateLessonRequestHandler(IRepositoryWithEvents<Lesson> repository) => _repository = repository;

    public async Task<long> Handle(CreateLessonRequest request, CancellationToken cancellationToken)
    {
        var lesson = new Lesson(
            request.LessonCode,
            request.LessonNameAra,
            request.LessonNameEng,
            request.SeasonId,
            request.DescriptionAra,
            request.DescriptionEng)
        {
            Attachment = request.Attachment
        };

        await _repository.AddAsync(lesson, cancellationToken);

        return lesson.Id;
    }
}
