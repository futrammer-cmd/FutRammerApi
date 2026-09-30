namespace FutRammerApi.Application.Academics.Teachers;

public class GetTeacherRequest : IRequest<TeacherDto>
{
    public long Id { get; set; }

    public GetTeacherRequest(long id) => Id = id;
}

public class TeacherByIdSpec : Specification<Teacher, TeacherDto>, ISingleResultSpecification
{
    public TeacherByIdSpec(long id) =>
        Query.Where(t => t.Id == id);
}

public class GetTeacherRequestHandler : IRequestHandler<GetTeacherRequest, TeacherDto>
{
    private readonly IRepository<Teacher> _repository;
    private readonly IStringLocalizer _t;

    public GetTeacherRequestHandler(IRepository<Teacher> repository, IStringLocalizer<GetTeacherRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<TeacherDto> Handle(GetTeacherRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<Teacher, TeacherDto>)new TeacherByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Teacher {0} Not Found.", request.Id]);
}
