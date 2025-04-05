using DVDRentalAPI.Application.Utilities.Errors;
using DVDRentalAPI.Application.Utilities.ServiceResponse;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalAPI.Presentation.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    public BaseApiController()
    {
    }

    protected virtual async Task<IActionResult> ApiResponse<T>(T result) where T : Result
    {
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        else if (result.Error == Error.NotFound || result.Error == Error.NotFoundByQuery)
        {
            return NotFound(result);
        }
        else
        {
            return BadRequest(result);
        }
    }
}
