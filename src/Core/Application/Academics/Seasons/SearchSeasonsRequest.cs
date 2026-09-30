namespace FutRammerApi.Application.Academics.Seasons;

public class SearchSeasonsRequest : PaginationFilter, IRequest<PaginationResponse<SeasonDto>>
{
}

public class SeasonsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Season, SeasonDto>
{
    public SeasonsBySearchRequestSpec(SearchSeasonsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.SeasonCode, !request.HasOrderBy());
}

public class SearchSeasonsRequestHandler : IRequestHandler<SearchSeasonsRequest, PaginationResponse<SeasonDto>>
{
    private readonly IReadRepository<Season> _repository;

    public SearchSeasonsRequestHandler(IReadRepository<Season> repository) => _repository = repository;

    public async Task<PaginationResponse<SeasonDto>> Handle(SearchSeasonsRequest request, CancellationToken cancellationToken)
    {
        var spec = new SeasonsBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
