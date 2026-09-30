using FutRammerApi.Application.Academics.Lessons;

namespace FutRammerApi.Host.Controllers.Academics;

public class LessonsController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Lessons)]
    [OpenApiOperation("Search lessons using available filters.", "")]
    public Task<PaginationResponse<LessonDto>> SearchAsync(SearchLessonsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:long}")]
    [MustHavePermission(FSHAction.View, FSHResource.Lessons)]
    [OpenApiOperation("Get lesson details.", "")]
    public Task<LessonDto> GetAsync(long id)
    {
        return Mediator.Send(new GetLessonRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Lessons)]
    [OpenApiOperation("Create a new lesson.", "")]
    public Task<long> CreateAsync(CreateLessonRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:long}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Lessons)]
    [OpenApiOperation("Update a lesson.", "")]
    public async Task<ActionResult<long>> UpdateAsync(UpdateLessonRequest request, long id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:long}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Lessons)]
    [OpenApiOperation("Delete a lesson.", "")]
    public Task<long> DeleteAsync(long id)
    {
        return Mediator.Send(new DeleteLessonRequest(id));
    }
}
