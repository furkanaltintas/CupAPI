using AutoMapper;
using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Dtos.OrderItemDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Services.Concrete;

public sealed class OrderItemService(
    IGenericRepository<OrderItem> orderItemRepository,
    IMapper mapper) : IOrderItemService
{
    public async Task<ApiResponse<string>> AddAsync(CreateOrderItemDto createOrderItemDto)
    {
        try
        {
            var orderItem = mapper.Map<OrderItem>(createOrderItemDto);
            await orderItemRepository.AddAsync(orderItem);
            await orderItemRepository.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.Table.Created);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Table.ErrorWhileAdding, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<string>> DeleteAsync(int id)
    {
        try
        {
            var orderItem = await orderItemRepository.GetByIdAsync(id);
            if (orderItem is null) return ApiResponse<String>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            orderItemRepository.Delete(orderItem);
            await orderItemRepository.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.Table.Deleted);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Table.ErrorWhileDeleting, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<List<ResultOrderItemDto>>> GetAllAsync()
    {
        try
        {
            var orderItems = await orderItemRepository.GetAllAsync();

            if (orderItems is null || !orderItems.Any()) return ApiResponse<List<ResultOrderItemDto>>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            var resultOrderItemDtos = mapper.Map<List<ResultOrderItemDto>>(orderItems);
            return ApiResponse<List<ResultOrderItemDto>>.SuccessResult(resultOrderItemDtos);
        }
        catch
        {
            return ApiResponse<List<ResultOrderItemDto>>.Fail(Messages.Table.ErrorWhileFetching, Common.Enums.ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<DetailOrderItemDto>> GetByIdAsync(int id)
    {
        try
        {
            var orderItem = await orderItemRepository.GetByIdAsync(id);
            if (orderItem is null) return ApiResponse<DetailOrderItemDto>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            var detailOrderItemDto = mapper.Map<DetailOrderItemDto>(orderItem);
            return ApiResponse<DetailOrderItemDto>.SuccessResult(detailOrderItemDto);
        }
        catch
        {
            return ApiResponse<DetailOrderItemDto>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<string>> UpdateAsync(UpdateOrderItemDto updateOrderItemDto)
    {
        try
        {
            var orderItem = await orderItemRepository.GetByIdAsync(updateOrderItemDto.Id);
            if (orderItem is null) return ApiResponse<String>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            mapper.Map(updateOrderItemDto, orderItem);
            orderItemRepository.Update(orderItem);
            await orderItemRepository.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.Table.Updated);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Table.ErrorWhileUpdating, ErrorCodeEnum.Exception);
        }
    }
}