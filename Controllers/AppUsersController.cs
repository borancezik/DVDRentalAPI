using DVDRentalAPI.Application.Dtos.AppUser;
using DVDRentalAPI.Application.Features.AppUser.Commands.Add;
using DVDRentalAPI.Application.Features.AppUser.Commands.Delete;
using DVDRentalAPI.Application.Features.AppUser.Commands.Patch;
using DVDRentalAPI.Application.Features.AppUser.Commands.Update;
using DVDRentalAPI.Application.Features.AppUser.Queries.Get;
using DVDRentalAPI.Presentation.Controllers.Base;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalAPI.Presentation.Controllers;

public class AppUsersController(ISender mediator, IMapper mapper) : BaseApiController
{
    private readonly ISender _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var queryResult = await _mediator.Send(new GetAppUserQuery(Id: id));

        return await ApiResponse(queryResult);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddAppUserCommand addAppUserCommand)
    {
        var queryResult = await _mediator.Send(addAppUserCommand);

        return await ApiResponse(queryResult);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAppUserCommand updateAppUserCommand)
    {
        var queryResult = await _mediator.Send(updateAppUserCommand);

        return await ApiResponse(queryResult);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteAppUserCommand deleteAppUserCommand)
    {
        var queryResult = await _mediator.Send(deleteAppUserCommand);

        return await ApiResponse(queryResult);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] PatchAppUserDto patchAppUserDto)
    {
        var command = _mapper.Map<PatchAppUserCommand>((id, patchAppUserDto));

        var queryResult = await _mediator.Send(command);

        return await ApiResponse(queryResult);
    }
}
