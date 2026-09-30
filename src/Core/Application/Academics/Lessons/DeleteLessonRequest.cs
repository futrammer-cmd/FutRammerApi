namespace FutRammerApi.Application.Academics.Lessons;

public class DeleteLessonRequest : IRequest<long>
{
    public long Id { get; set; }

    public DeleteLessonRequest(long id) => Id = id;
}

public class DeleteLessonRequestHandler : IRequestHandler<DeleteLessonRequest, long>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Lesson> _repository;
    private readonly IStringLocalizer _t;

    public DeleteLessonRequestHandler(IRepositoryWithEvents<Lesson> repository, IStringLocalizer<DeleteLessonRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<long> Handle(DeleteLessonRequest request, CancellationToken cancellationToken)
    {
        var lesson = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = lesson ?? throw new NotFoundException(_t["Lesson {0} Not Found.", request.Id]);

        await _repository.DeleteAsync(lesson, cancellationToken);

        return request.Id;
    }
}
