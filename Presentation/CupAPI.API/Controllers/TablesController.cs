using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Application.Features.Table.Commands.CreateTable;
using CupAPI.Application.Features.Table.Commands.DeleteTable;
using CupAPI.Application.Features.Table.Commands.UpdateTable;
using CupAPI.Application.Features.Table.Queries.GetAllTables;
using CupAPI.Application.Features.Table.Queries.GetTableByCode;
using CupAPI.Application.Features.Table.Queries.GetTableById;
using CupAPI.Application.Features.Table.Queries.GetTableByNumber;
using CupAPI.Application.Features.Table.Queries.GetTableByType;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthorizationPolicy = CupAPI.Domain.Enums.AuthorizationPolicy;

namespace CupAPI.API.Controllers;

[Authorize(Policy = AuthorizationPolicy.AdminAndEmployeeOnly)]
public class TablesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await Mediator.Send(new GetAllTablesQuery());
        return HandleResponse(response);
    }

    [HttpGet("id/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await Mediator.Send(new GetTableByIdQuery(id));
        return HandleResponse(response);
    }

    [HttpGet("code/{tableCode}")]
    public async Task<IActionResult> GetByCode(string tableCode)
    {
        var response = await Mediator.Send(new GetTableByCodeQuery(tableCode));
        return HandleResponse(response);
    }

    [HttpGet("number/{tableNumber:int}")]
    public async Task<IActionResult> GetByNumber(int tableNumber)
    {
        var response = await Mediator.Send(new GetTableByNumberQuery(tableNumber));
        return HandleResponse(response);
    }

    [HttpGet("type/{tableType}")]
    public async Task<IActionResult> GetByType(TableType tableType)
    {
        var response = await Mediator.Send(new GetTableByTypeQuery(tableType));
        return HandleResponse(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTableDto createTableDto)
    {
        var response = await Mediator.Send(new CreateTableCommand(createTableDto));
        return HandleResponse(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTableDto updateTableDto)
    {
        var response = await Mediator.Send(new UpdateTableCommand(updateTableDto));
        return HandleResponse(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await Mediator.Send(new DeleteTableCommand(id));
        return HandleResponse(response);
    }
}