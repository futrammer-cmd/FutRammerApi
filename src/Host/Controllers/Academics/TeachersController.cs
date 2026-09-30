using FutRammerApi.Application.Academics.Teachers;

namespace FutRammerApi.Host.Controllers.Academics;

public class TeachersController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Teachers)]
    [OpenApiOperation("Search teachers using available filters.", "")]
    public Task<PaginationResponse<TeacherDto>> SearchAsync(SearchTeachersRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:long}")]
    [MustHavePermission(FSHAction.View, FSHResource.Teachers)]
    [OpenApiOperation("Get teacher details.", "")]
    public Task<TeacherDto> GetAsync(long id)
    {
        return Mediator.Send(new GetTeacherRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Teachers)]
    [OpenApiOperation("Create a new teacher.", "")]
    public Task<long> CreateAsync(CreateTeacherRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:long}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Teachers)]
    [OpenApiOperation("Update a teacher.", "")]
    public async Task<ActionResult<long>> UpdateAsync(UpdateTeacherRequest request, long id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:long}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Teachers)]
    [OpenApiOperation("Delete a teacher.", "")]
    public Task<long> DeleteAsync(long id)
    {
        return Mediator.Send(new DeleteTeacherRequest(id));
    }
}
