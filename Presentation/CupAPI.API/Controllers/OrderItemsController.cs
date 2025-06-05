//using CupAPI.API.Controllers.Common;
//using CupAPI.Application.Dtos.OrderItemDtos;
//using CupAPI.Application.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace CupAPI.API.Controllers;

//public class OrderItemsController(IOrderItemService orderItemService) : BaseApiController
//{
//    [HttpGet]
//    public async Task<IActionResult> GetAll()
//    {
//        var response = await orderItemService.GetAllAsync();
//        return HandleResponse(response);
//    }

//    [HttpGet("{id}")]
//    public async Task<IActionResult> GetById([FromRoute] int id)
//    {
//        var response = await orderItemService.GetByIdAsync(id);
//        return HandleResponse(response);
//    }

//    [HttpPost]
//    public async Task<IActionResult> Add([FromBody] CreateOrderItemDto createOrderItemDto)
//    {
//        var response = await orderItemService.AddAsync(createOrderItemDto);
//        return HandleResponse(response);
//    }

//    [HttpPut]
//    public async Task<IActionResult> Update([FromBody] UpdateOrderItemDto updateOrderItemDto)
//    {
//        var response = await orderItemService.UpdateAsync(updateOrderItemDto);
//        return HandleResponse(response);
//    }

//    [HttpDelete]
//    public async Task<IActionResult> Delete(int id)
//    {
//        var response = await orderItemService.DeleteAsync(id);
//        return HandleResponse(response);
//    }
//}