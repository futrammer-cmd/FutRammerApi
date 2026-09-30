namespace FutRammerApi.Application.Academics.Lessons;

public class SearchLessonsRequest : PaginationFilter, IRequest<PaginationResponse<LessonDto>>
{
}

public class LessonsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Lesson, LessonDto>
{
    public LessonsBySearchRequestSpec(SearchLessonsRequest request)
        : base(request) =>
        Query
            .Include(l => l.Season)
            .OrderBy(c => c.LessonCode, !request.HasOrderBy());
}

public class SearchLessonsRequestHandler : IRequestHandler<SearchLessonsRequest, PaginationResponse<LessonDto>>
{
    private readonly IReadRepository<Lesson> _repository;

    public SearchLessonsRequestHandler(IReadRepository<Lesson> repository) => _repository = repository;

    public async Task<PaginationResponse<LessonDto>> Handle(SearchLessonsRequest request, CancellationToken cancellationToken)
    {
        var spec = new LessonsBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
