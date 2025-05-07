using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TablesController(ITableService tableService) : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAllTables()
    {
        var response = await tableService.GetAllAsync();
        return HandleResponse(response);
    }

    [HttpGet("id/{id:int}")]
    public async Task<IActionResult> GetByIdTable(int id)
    {
        var response = await tableService.GetByIdAsync(id);
        return HandleResponse(response);
    }

    [HttpGet("code/{tableCode}")]
    public async Task<IActionResult> GetByCode(string tableCode)
    {
        var response = await tableService.GetByCodeAsync(tableCode);
        return HandleResponse(response);
    }

    [HttpGet("number/{tableNumber:int}")]
    public async Task<IActionResult> GetByNumber(int tableNumber)
    {
        var response = await tableService.GetByNumberAsync(tableNumber);
        return HandleResponse(response);
    }

    [HttpGet("type/{tableType:TableType}")]
    public async Task<IActionResult> GetByType(TableType tableType)
    {
        var response = await tableService.GetByTypeAsync(tableType);
        return HandleResponse(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddTable([FromBody] CreateTableDto createTableDto)
    {
        var response =  await tableService.AddAsync(createTableDto);
        return HandleResponse(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTable([FromBody] UpdateTableDto updateTableDto)
    {
        var response = await tableService.UpdateAsync(updateTableDto);
        return HandleResponse(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTable(int id)
    {
        var response = await tableService.DeleteAsync(id);
        return HandleResponse(response);
    }
}