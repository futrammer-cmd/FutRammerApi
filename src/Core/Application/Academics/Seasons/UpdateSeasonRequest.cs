namespace FutRammerApi.Application.Academics.Seasons;

public class UpdateSeasonRequest : IRequest<long>
{
    public long Id { get; set; }
    public string SeasonCode { get; set; } = default!;
    public string SeasonNameAra { get; set; } = default!;
    public string SeasonNameEng { get; set; } = default!;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? DescriptionAra { get; set; }
    public string? DescriptionEng { get; set; }
    public string? Notes { get; set; }
    public string? Attachment { get; set; }
    public bool? IsActive { get; set; }
}

public class UpdateSeasonRequestValidator : CustomValidator<UpdateSeasonRequest>
{
    public UpdateSeasonRequestValidator(IRepository<Season> repository, IStringLocalizer<UpdateSeasonRequestValidator> T)
    {
        RuleFor(p => p.SeasonCode)
            .NotEmpty()
            .MaximumLength(50)
            .MustAsync(async (season, code, ct) =>
                    await repository.FirstOrDefaultAsync(new SeasonByCodeSpec(code), ct)
                        is not Season existingSeason || existingSeason.Id == season.Id)
                .WithMessage((_, code) => T["Season Code {0} already Exists.", code]);

        RuleFor(p => p.SeasonNameAra)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(p => p.SeasonNameEng)
            .NotEmpty()
            .MaximumLength(256);
    }
}

public class UpdateSeasonRequestHandler : IRequestHandler<UpdateSeasonRequest, long>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Season> _repository;
    private readonly IStringLocalizer _t;

    public UpdateSeasonRequestHandler(IRepositoryWithEvents<Season> repository, IStringLocalizer<UpdateSeasonRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<long> Handle(UpdateSeasonRequest request, CancellationToken cancellationToken)
    {
        var season = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = season
        ?? throw new NotFoundException(_t["Season {0} Not Found.", request.Id]);

        season.Update(
            request.SeasonCode,
            request.SeasonNameAra,
            request.SeasonNameEng,
            request.StartDate,
            request.EndDate,
            request.DescriptionAra,
            request.DescriptionEng,
            request.Notes,
            request.Attachment,
            request.IsActive);

        await _repository.UpdateAsync(season, cancellationToken);

        return request.Id;
    }
}
