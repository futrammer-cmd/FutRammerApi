namespace FutRammerApi.Application.Academics.Teachers;

public class DeleteTeacherRequest : IRequest<long>
{
    public long Id { get; set; }

    public DeleteTeacherRequest(long id) => Id = id;
}

public class DeleteTeacherRequestHandler : IRequestHandler<DeleteTeacherRequest, long>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Teacher> _repository;
    private readonly IStringLocalizer _t;

    public DeleteTeacherRequestHandler(IRepositoryWithEvents<Teacher> repository, IStringLocalizer<DeleteTeacherRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<long> Handle(DeleteTeacherRequest request, CancellationToken cancellationToken)
    {
        var teacher = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = teacher ?? throw new NotFoundException(_t["Teacher {0} Not Found.", request.Id]);

        await _repository.DeleteAsync(teacher, cancellationToken);

        return request.Id;
    }
}
