using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Features.Category.Commands.CreateCategory;
using CupAPI.Application.Features.Category.Commands.DeleteCategory;
using CupAPI.Application.Features.Category.Commands.UpdateCategory;
using CupAPI.Application.Features.Category.Queries.GetAllCategories;
using CupAPI.Application.Features.Category.Queries.GetCategoriesWithMenuItems;
using CupAPI.Application.Features.Category.Queries.GetCategoryById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthorizationPolicy = CupAPI.Domain.Enums.AuthorizationPolicy;

namespace CupAPI.API.Controllers;

public class CategoriesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await Mediator.Send(new GetAllCategoriesQuery());
        return HandleResponse(response);
    }

    [HttpGet("withmenuitems")]
    public async Task<IActionResult> GetAllCategoriesWithMenuItems()
    {
        var response = await Mediator.Send(new GetCategoriesWithMenuItemsQuery());
        return HandleResponse(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await Mediator.Send(new GetCategoryByIdQuery(id));
        return HandleResponse(response);
    }

    [Authorize(Policy = AuthorizationPolicy.AdminOnly)]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryDto createCategoryDto)
    {
        var response = await Mediator.Send(new CreateCategoryCommand(createCategoryDto));
        return HandleResponse(response);
    }

    [Authorize(Policy = AuthorizationPolicy.AdminOnly)]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryDto updateCategoryDto)
    {
        var response = await Mediator.Send(new UpdateCategoryCommand(updateCategoryDto));
        return HandleResponse(response);
    }

    [Authorize(Policy = AuthorizationPolicy.AdminOnly)]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await Mediator.Send(new DeleteCategoryCommand(id));
        return HandleResponse(response);
    }
}