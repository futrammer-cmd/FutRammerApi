namespace FutRammerApi.Application.Academics.Lessons;

public class GetLessonRequest : IRequest<LessonDto>
{
    public long Id { get; set; }

    public GetLessonRequest(long id) => Id = id;
}

public class LessonByIdSpec : Specification<Lesson, LessonDto>, ISingleResultSpecification
{
    public LessonByIdSpec(long id) =>
        Query
            .Where(l => l.Id == id)
            .Include(l => l.Season);
}

public class GetLessonRequestHandler : IRequestHandler<GetLessonRequest, LessonDto>
{
    private readonly IRepository<Lesson> _repository;
    private readonly IStringLocalizer _t;

    public GetLessonRequestHandler(IRepository<Lesson> repository, IStringLocalizer<GetLessonRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<LessonDto> Handle(GetLessonRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<Lesson, LessonDto>)new LessonByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Lesson {0} Not Found.", request.Id]);
}
