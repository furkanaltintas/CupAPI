using Microsoft.AspNetCore.Mvc;
using CupAPI.Application.Dtos.ResponseDtos;

namespace CupAPI.API.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    protected IActionResult HandleResponse<T>(ResponseDto<T> response) where T : class
    {
        if (response.Success) return Ok(response);

        return response.ErrorCode switch
        {
            ErrorCode.NotFound => NotFound(response),
            ErrorCode.BadRequest => BadRequest(response),
            ErrorCode.Unauthorized => Unauthorized(response),
            ErrorCode.ValidationError => UnprocessableEntity(response),
            ErrorCode.Conflict => Conflict(response),
            ErrorCode.Forbidden => Forbid(),
            _ => StatusCode(500, response)
        };
    }
}
