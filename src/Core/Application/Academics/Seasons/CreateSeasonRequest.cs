namespace FutRammerApi.Application.Academics.Seasons;

public class CreateSeasonRequest : IRequest<long>
{
    public string SeasonCode { get; set; } = default!;
    public string SeasonNameAra { get; set; } = default!;
    public string SeasonNameEng { get; set; } = default!;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? DescriptionAra { get; set; }
    public string? DescriptionEng { get; set; }
    public string? Attachment { get; set; }
}

public class CreateSeasonRequestValidator : CustomValidator<CreateSeasonRequest>
{
    public CreateSeasonRequestValidator(IReadRepository<Season> repository, IStringLocalizer<CreateSeasonRequestValidator> T)
    {
        RuleFor(p => p.SeasonCode)
            .NotEmpty()
            .MaximumLength(50)
            .MustAsync(async (code, ct) => await repository.FirstOrDefaultAsync(new SeasonByCodeSpec(code), ct) is null)
                .WithMessage((_, code) => T["Season Code {0} already Exists.", code]);

        RuleFor(p => p.SeasonNameAra)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(p => p.SeasonNameEng)
            .NotEmpty()
            .MaximumLength(256);
    }
}

public class CreateSeasonRequestHandler : IRequestHandler<CreateSeasonRequest, long>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Season> _repository;

    public CreateSeasonRequestHandler(IRepositoryWithEvents<Season> repository) => _repository = repository;

    public async Task<long> Handle(CreateSeasonRequest request, CancellationToken cancellationToken)
    {
        var season = new Season(
            request.SeasonCode,
            request.SeasonNameAra,
            request.SeasonNameEng,
            request.StartDate,
            request.EndDate,
            request.DescriptionAra,
            request.DescriptionEng)
        {
            Attachment = request.Attachment
        };

        await _repository.AddAsync(season, cancellationToken);

        return season.Id;
    }
}
