﻿using AutoMapper;
using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Dtos.OrderDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;
using CupAPI.Domain.Enums;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CupAPI.Application.Services.Concrete;

public class OrderService(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IValidator<CreateOrderDto> createOrderValidator,
    IValidator<UpdateOrderDto> updateOrderValidator) : IOrderService
{
    public async Task<ApiResponse<String>> AddAsync(CreateOrderDto createOrderDto)
    {
        try
        {
            var validate = await createOrderValidator.ValidateAsync(createOrderDto);
            if (!validate.IsValid) return ApiResponse<String>.Fail(string.Join(",", validate.Errors.Select(v => v.ErrorMessage)), ErrorCodeEnum.ValidationError);

            var menuItems = await unitOfWork.MenuItems.GetAllAsync(m => createOrderDto.OrderItems.Select(o => o.MenuItemId).Contains(m.Id));

            var orderItems = createOrderDto.OrderItems.Select(item =>
            {
                var menuItem = menuItems.First(m => m.Id == item.MenuItemId);
                return new OrderItem
                {
                    MenuItemId = item.MenuItemId,
                    Quantity = item.Quantity,
                    Price = menuItem.Price
                };
            }).ToList();

            var totalPrice = orderItems.Sum(o => o.TotalPrice);

            var order = new Order
            {
                TableId = createOrderDto.TableId,
                CreatedAt = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };

            var table = await unitOfWork.Tables.GetByIdAsync(order.TableId);
            table.IsActive = false;

            await unitOfWork.Orders.AddAsync(order);
            unitOfWork.Tables.Update(table);

            await unitOfWork.Orders.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.Order.Created);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Order.ErrorWhileAdding, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<String>> UpdateOrderWithItemAsync(AddOrderItemToOrderDto addOrderItemToOrderDto)
    {
        var order = await unitOfWork.Orders.FirstOrDefaultAsync(
            o => o.Id == addOrderItemToOrderDto.OrderId,
            o => o.Include(o => o.OrderItems));

        if (order is null) return ApiResponse<String>.Fail(Messages.Order.ErrorWhileFetching, ErrorCodeEnum.NotFound);

        var newOrderItem = mapper.Map<OrderItem>(addOrderItemToOrderDto.OrderItem);

        var existingOrderItem = order.OrderItems
            .FirstOrDefault(o => o.MenuItemId == newOrderItem.MenuItemId);

        if (existingOrderItem is not null)
        {
            // Eğer aynı ürün varsa miktarı arttırıyoruz
            existingOrderItem.Quantity += newOrderItem.Quantity;
            order.TotalPrice = order.OrderItems.Sum(o => o.TotalPrice);
        }
        else
        {
            order.OrderItems.Add(newOrderItem);
            order.TotalPrice = order.OrderItems.Sum(o => o.TotalPrice);
        }

        unitOfWork.Orders.Update(order);
        await unitOfWork.Orders.SaveChangesAsync();

        return ApiResponse<String>.SuccessNoDataResult(Messages.Order.Updated);
    }

    public async Task<ApiResponse<String>> ChangeOrderStatusAsync(ChangeOrderStatusDto changeOrderStatusDto)
    {
        try
        {
            var order = await unitOfWork.Orders.GetByIdAsync(changeOrderStatusDto.OrderId);
            if (order is null) return ApiResponse<String>.Fail(Messages.Order.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            mapper.Map(changeOrderStatusDto, order);
            unitOfWork.Orders.Update(order);

            if (changeOrderStatusDto.NewStatus == OrderType.Completed)
            {
                var table = await unitOfWork.Tables.GetByIdAsync(order.TableId);
                table.IsActive = true;
                unitOfWork.Tables.Update(table);
            }

            await unitOfWork.Orders.SaveChangesAsync();
            return ApiResponse<string>.SuccessNoDataResult(Messages.Order.Updated);
        }
        catch
        {
            return ApiResponse<string>.Fail(Messages.Order.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<String>> DeleteAsync(int id)
    {
        try
        {
            var order = await unitOfWork.Orders.GetByIdAsync(id);
            if (order is null) return ApiResponse<String>.Fail(Messages.Order.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            unitOfWork.Orders.Delete(order);
            await unitOfWork.Orders.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.Order.Deleted);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Order.ErrorWhileDeleting, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<List<ResultOrderDto>>> GetAllAsync()
    {
        try
        {
            var orders = await unitOfWork.Orders.GetAllOrderWithDetailAsync();
            if (orders is null || !orders.Any()) return ApiResponse<List<ResultOrderDto>>.SuccessEmptyDataResult(new(), Messages.General.DataIsEmpty, ErrorCodeEnum.EmptyData);

            var resultOrderDtos = mapper.Map<List<ResultOrderDto>>(orders);
            return ApiResponse<List<ResultOrderDto>>.SuccessResult(resultOrderDtos);
        }
        catch
        {
            return ApiResponse<List<ResultOrderDto>>.Fail(Messages.Order.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<DetailOrderDto>> GetByIdAsync(int id)
    {
        try
        {
            var order = await unitOfWork.Orders.GetOrderByIdWithDetailAsync(id);
            if (order is null) return ApiResponse<DetailOrderDto>.Fail(Messages.Order.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            var detailOrderDto = mapper.Map<DetailOrderDto>(order);
            return ApiResponse<DetailOrderDto>.SuccessResult(detailOrderDto);
        }
        catch
        {
            return ApiResponse<DetailOrderDto>.Fail(Messages.Order.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<String>> UpdateAsync(UpdateOrderDto updateOrderDto)
    {
        try
        {
            var validate = await updateOrderValidator.ValidateAsync(updateOrderDto);
            if (!validate.IsValid) return ApiResponse<String>.Fail(string.Join(",", validate.Errors.Select(v => v.ErrorMessage)), ErrorCodeEnum.ValidationError);

            var order = await unitOfWork.Orders.GetByIdAsync(updateOrderDto.Id);
            if (order is null) return ApiResponse<String>.Fail(Messages.Order.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            mapper.Map(updateOrderDto, order);
            unitOfWork.Orders.Update(order);
            await unitOfWork.Orders.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.Order.Updated);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Order.ErrorWhileUpdating, ErrorCodeEnum.Exception);
        }
    }
}