using Microsoft.AspNetCore.Mvc;
using CupAPI.Application.Common.Responses;
using CupAPI.Application.Common.Enums;

namespace CupAPI.API.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    protected IActionResult HandleResponse<T>(ApiResponse<T> response) where T : class
    {
        if (response.Success) return Ok(response);

        return response.ErrorCode switch
        {
            ErrorCodeEnum.NotFound => NotFound(response),
            ErrorCodeEnum.BadRequest => BadRequest(response),
            ErrorCodeEnum.Unauthorized => Unauthorized(response),
            ErrorCodeEnum.ValidationError => UnprocessableEntity(response),
            ErrorCodeEnum.Conflict => Conflict(response),
            ErrorCodeEnum.Forbidden => Forbid(),
            _ => StatusCode(500, response)
        };
    }
}
