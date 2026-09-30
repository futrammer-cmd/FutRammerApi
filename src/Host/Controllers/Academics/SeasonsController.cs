using FutRammerApi.Application.Academics.Seasons;

namespace FutRammerApi.Host.Controllers.Academics;

public class SeasonsController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Seasons)]
    [OpenApiOperation("Search seasons using available filters.", "")]
    public Task<PaginationResponse<SeasonDto>> SearchAsync(SearchSeasonsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:long}")]
    [MustHavePermission(FSHAction.View, FSHResource.Seasons)]
    [OpenApiOperation("Get season details.", "")]
    public Task<SeasonDto> GetAsync(long id)
    {
        return Mediator.Send(new GetSeasonRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Seasons)]
    [OpenApiOperation("Create a new season.", "")]
    public Task<long> CreateAsync(CreateSeasonRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:long}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Seasons)]
    [OpenApiOperation("Update a season.", "")]
    public async Task<ActionResult<long>> UpdateAsync(UpdateSeasonRequest request, long id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:long}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Seasons)]
    [OpenApiOperation("Delete a season.", "")]
    public Task<long> DeleteAsync(long id)
    {
        return Mediator.Send(new DeleteSeasonRequest(id));
    }
}
