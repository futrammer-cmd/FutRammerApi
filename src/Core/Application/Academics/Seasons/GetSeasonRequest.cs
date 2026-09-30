namespace FutRammerApi.Application.Academics.Seasons;

public class GetSeasonRequest : IRequest<SeasonDto>
{
    public long Id { get; set; }

    public GetSeasonRequest(long id) => Id = id;
}

public class SeasonByIdSpec : Specification<Season, SeasonDto>, ISingleResultSpecification
{
    public SeasonByIdSpec(long id) =>
        Query.Where(p => p.Id == id);
}

public class GetSeasonRequestHandler : IRequestHandler<GetSeasonRequest, SeasonDto>
{
    private readonly IRepository<Season> _repository;
    private readonly IStringLocalizer _t;

    public GetSeasonRequestHandler(IRepository<Season> repository, IStringLocalizer<GetSeasonRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<SeasonDto> Handle(GetSeasonRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<Season, SeasonDto>)new SeasonByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Season {0} Not Found.", request.Id]);
}
