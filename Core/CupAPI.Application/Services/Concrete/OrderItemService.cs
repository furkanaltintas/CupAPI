using AutoMapper;
using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Dtos.OrderItemDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;
using FluentValidation;

namespace CupAPI.Application.Services.Concrete;

public sealed class OrderItemService(
    IOrderItemRepository orderItemRepository,
    IMapper mapper,
    IValidator<CreateOrderItemDto> createOrderItemValidator,
    IValidator<UpdateOrderItemDto> updateOrderItemValidator) : IOrderItemService
{
    public async Task<ApiResponse<String>> AddAsync(CreateOrderItemDto createOrderItemDto)
    {
        try
        {
            var validate = await createOrderItemValidator.ValidateAsync(createOrderItemDto);
            if (!validate.IsValid) return ApiResponse<String>.Fail(string.Join(",", validate.Errors.Select(v => v.ErrorMessage)), ErrorCodeEnum.ValidationError);

            var orderItem = mapper.Map<OrderItem>(createOrderItemDto);
            await orderItemRepository.AddAsync(orderItem);
            await orderItemRepository.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.OrderItem.Created);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.OrderItem.ErrorWhileAdding, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<String>> DeleteAsync(int id)
    {
        try
        {
            var orderItem = await orderItemRepository.GetByIdAsync(id);
            if (orderItem is null) return ApiResponse<String>.Fail(Messages.OrderItem.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            orderItemRepository.Delete(orderItem);
            await orderItemRepository.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.OrderItem.Deleted);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.OrderItem.ErrorWhileDeleting, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<List<ResultOrderItemDto>>> GetAllAsync()
    {
        try
        {
            var orderItems = await orderItemRepository.GetAllAsync();
            if (orderItems is null || !orderItems.Any()) return ApiResponse<List<ResultOrderItemDto>>.SuccessEmptyDataResult(new(), Messages.General.DataIsEmpty, ErrorCodeEnum.EmptyData);

            var resultOrderItemDtos = mapper.Map<List<ResultOrderItemDto>>(orderItems);
            return ApiResponse<List<ResultOrderItemDto>>.SuccessResult(resultOrderItemDtos);
        }
        catch
        {
            return ApiResponse<List<ResultOrderItemDto>>.Fail(Messages.OrderItem.ErrorWhileFetching, Common.Enums.ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<DetailOrderItemDto>> GetByIdAsync(int id)
    {
        try
        {
            var orderItem = await orderItemRepository.GetByIdAsync(id);
            if (orderItem is null) return ApiResponse<DetailOrderItemDto>.Fail(Messages.OrderItem.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            var detailOrderItemDto = mapper.Map<DetailOrderItemDto>(orderItem);
            return ApiResponse<DetailOrderItemDto>.SuccessResult(detailOrderItemDto);
        }
        catch
        {
            return ApiResponse<DetailOrderItemDto>.Fail(Messages.OrderItem.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<String>> UpdateAsync(UpdateOrderItemDto updateOrderItemDto)
    {
        try
        {
            var validate = await updateOrderItemValidator.ValidateAsync(updateOrderItemDto);
            if (!validate.IsValid) return ApiResponse<String>.Fail(string.Join(",", validate.Errors.Select(v => v.ErrorMessage)), ErrorCodeEnum.ValidationError);

            var orderItem = await orderItemRepository.GetByIdAsync(updateOrderItemDto.Id);
            if (orderItem is null) return ApiResponse<String>.Fail(Messages.OrderItem.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            mapper.Map(updateOrderItemDto, orderItem);
            orderItemRepository.Update(orderItem);
            await orderItemRepository.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.OrderItem.Updated);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.OrderItem.ErrorWhileUpdating, ErrorCodeEnum.Exception);
        }
    }
}