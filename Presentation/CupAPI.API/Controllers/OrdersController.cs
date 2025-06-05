using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.OrderDtos;
using CupAPI.Application.Features.Order.Commands.AddOrderItemByOrder;
using CupAPI.Application.Features.Order.Commands.ChangeOrderStatus;
using CupAPI.Application.Features.Order.Commands.CreateOrder;
using CupAPI.Application.Features.Order.Commands.DeleteOrder;
using CupAPI.Application.Features.Order.Commands.UpdateOrder;
using CupAPI.Application.Features.Order.Queries.GetAllOrders;
using CupAPI.Application.Features.Order.Queries.GetOrderById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthorizationPolicy = CupAPI.Domain.Enums.AuthorizationPolicy;

namespace CupAPI.API.Controllers;

[Authorize(Policy = AuthorizationPolicy.AdminAndEmployeeOnly)]
public class OrdersController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await Mediator.Send(new GetAllOrdersQuery());
        return HandleResponse(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await Mediator.Send(new GetOrderByIdQuery(id));
        return HandleResponse(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOrderDto createOrderDto)
    {
        var response = await Mediator.Send(new CreateOrderCommand(createOrderDto));
        return HandleResponse(response);
    }

    [HttpPost("changeorderstatus")]
    public async Task<IActionResult> ChangeOrderStatus(ChangeOrderStatusDto changeOrderStatusDto)
    {
        var response = await Mediator.Send(new ChangeOrderStatusCommand(changeOrderStatusDto));
        return HandleResponse(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderDto updateOrderDto)
    {
        var response = await Mediator.Send(new UpdateOrderCommand(updateOrderDto));
        return HandleResponse(response);
    }

    [HttpPut("addorderitembyorder")]
    public async Task<IActionResult> AddOrderItemByOrder(AddOrderItemToOrderDto addOrderItemToOrderDto)
    {
        var response = await Mediator.Send(new AddOrderItemToOrderCommand(addOrderItemToOrderDto));
        return HandleResponse(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await Mediator.Send(new DeleteOrderCommand(id));
        return HandleResponse(response);
    }
}