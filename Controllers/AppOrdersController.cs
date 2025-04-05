using DVDRentalAPI.Application.Dtos.AppOrder;
using DVDRentalAPI.Application.Features.AppOrder.Commands.Add;
using DVDRentalAPI.Application.Features.AppOrder.Commands.Delete;
using DVDRentalAPI.Application.Features.AppOrder.Commands.Patch;
using DVDRentalAPI.Application.Features.AppOrder.Commands.Update;
using DVDRentalAPI.Application.Features.AppOrder.Queries.Get;
using DVDRentalAPI.Application.Features.AppOrder.Queries.GetPage;
using DVDRentalAPI.Presentation.Controllers.Base;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalAPI.Presentation.Controllers;

public class AppOrdersController(ISender mediator, IMapper mapper) : BaseApiController
{
    private readonly ISender _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var queryResult = await _mediator.Send(new GetAppOrderQuery(Id: id));

        return await ApiResponse(queryResult);
    }

    [HttpGet]
    public async Task<IActionResult> GetPage(GetPageAppOrderQuery getPageAppOrderQuery)
    {
        var queryResult = await _mediator.Send(getPageAppOrderQuery);

        return await ApiResponse(queryResult);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddAppOrderCommand addAppOrderCommand)
    {
        var queryResult = await _mediator.Send(addAppOrderCommand);

        return await ApiResponse(queryResult);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAppOrderCommand updateAppOrderCommand)
    {
        var queryResult = await _mediator.Send(updateAppOrderCommand);

        return await ApiResponse(queryResult);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteAppOrderCommand deleteAppOrderCommand)
    {
        var queryResult = await _mediator.Send(deleteAppOrderCommand);

        return await ApiResponse(queryResult);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] PatchAppOrderDto patchAppOrderDto)
    {
        var command = _mapper.Map<PatchAppOrderCommand>((id, patchAppOrderDto));

        var queryResult = await _mediator.Send(command);

        return await ApiResponse(queryResult);
    }
}
