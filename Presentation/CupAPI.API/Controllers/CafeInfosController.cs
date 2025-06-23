using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.CafeInfoDtos;
using CupAPI.Application.Features.CafeInfo.Commands.CreateCafeInfo;
using CupAPI.Application.Features.CafeInfo.Commands.DeleteCafeInfo;
using CupAPI.Application.Features.CafeInfo.Commands.UpdateCafeInfo;
using CupAPI.Application.Features.CafeInfo.Queries.GetAllCafeInfos;
using CupAPI.Application.Features.CafeInfo.Queries.GetCafeInfoById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthorizationPolicy = CupAPI.Domain.Enums.AuthorizationPolicy;

namespace CupAPI.API.Controllers;

public class CafeInfosController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await Mediator.Send(new GetAllCafeInfosQuery());
        return HandleResponse(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await Mediator.Send(new GetCafeInfoByIdQuery(id));
        return HandleResponse(response);
    }

    [Authorize(Policy = AuthorizationPolicy.AdminOnly)]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCafeInfoDto createCafeInfoDto)
    {
        var response = await Mediator.Send(new CreateCafeInfoCommand(createCafeInfoDto));
        return HandleResponse(response);
    }

    [Authorize(Policy = AuthorizationPolicy.AdminOnly)]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCafeInfoDto updateCafeInfoDto)
    {
        var response = await Mediator.Send(new UpdateCafeInfoCommand(updateCafeInfoDto));
        return HandleResponse(response);
    }

    [Authorize(Policy = AuthorizationPolicy.AdminOnly)]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await Mediator.Send(new DeleteCafeInfoCommand(id));
        return HandleResponse(response);
    }
}
