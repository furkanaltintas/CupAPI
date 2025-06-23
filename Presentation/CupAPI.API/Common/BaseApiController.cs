using CupAPI.Application.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers.Common;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

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
            ErrorCodeEnum.Forbidden => StatusCode(403, response),
            _ => StatusCode(500, response)
        };
    }
}