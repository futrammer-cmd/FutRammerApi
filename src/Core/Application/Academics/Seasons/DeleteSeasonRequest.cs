namespace FutRammerApi.Application.Academics.Seasons;

public class DeleteSeasonRequest : IRequest<long>
{
    public long Id { get; set; }

    public DeleteSeasonRequest(long id) => Id = id;
}

public class DeleteSeasonRequestHandler : IRequestHandler<DeleteSeasonRequest, long>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Season> _repository;
    private readonly IStringLocalizer _t;

    public DeleteSeasonRequestHandler(IRepositoryWithEvents<Season> repository, IStringLocalizer<DeleteSeasonRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<long> Handle(DeleteSeasonRequest request, CancellationToken cancellationToken)
    {
        var season = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = season ?? throw new NotFoundException(_t["Season {0} Not Found.", request.Id]);

        await _repository.DeleteAsync(season, cancellationToken);

        return request.Id;
    }
}
