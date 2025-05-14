using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.OrderDtos;
using CupAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers;

public class OrdersController(IOrderService orderService) : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await orderService.GetAllAsync();
        return HandleResponse(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await orderService.GetByIdAsync(id);
        return HandleResponse(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOrderDto createOrderDto)
    {
        var response = await orderService.AddAsync(createOrderDto);
        return HandleResponse(response);
    }

    [HttpPost("changeOrderStatus")]
    public async Task<IActionResult> ChangeOrderStatus(ChangeOrderStatusDto changeOrderStatusDto)
    {
        var response = await orderService.ChangeOrderStatusAsync(changeOrderStatusDto);
        return HandleResponse(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderDto updateOrderDto)
    {
        var response = await orderService.UpdateAsync(updateOrderDto);
        return HandleResponse(response);
    }

    [HttpPut("addOrderItemByOrder")]
    public async Task<IActionResult> AddOrderItemByOrder(AddOrderItemToOrderDto addOrderItemToOrderDto)
    {
        var response = await orderService.UpdateOrderWithItemAsync(addOrderItemToOrderDto);
        return HandleResponse(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await orderService.DeleteAsync(id);
        return HandleResponse(response);
    }
}