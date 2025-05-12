using AutoMapper;
using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Dtos.OrderDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;
using FluentValidation;

namespace CupAPI.Application.Services.Concrete;

public class OrderService(
    IGenericRepository<Order> orderRepository,
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

            var order = mapper.Map<Order>(createOrderDto);
            await orderRepository.AddAsync(order);
            await orderRepository.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.Order.Created);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Order.ErrorWhileAdding, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<String>> DeleteAsync(int id)
    {
        try
        {
            var order = await orderRepository.GetByIdAsync(id);
            if (order is null) return ApiResponse<String>.Fail(Messages.Order.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            orderRepository.Delete(order);
            await orderRepository.SaveChangesAsync();

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
            var orders = await orderRepository.GetAllAsync();
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
            var order = await orderRepository.GetByIdAsync(id);
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

            var order = await orderRepository.GetByIdAsync(updateOrderDto.Id);
            if (order is null) return ApiResponse<String>.Fail(Messages.Order.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            mapper.Map(updateOrderDto, order);
            orderRepository.Update(order);
            await orderRepository.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.Order.Updated);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Order.ErrorWhileUpdating, ErrorCodeEnum.Exception);
        }
    }
}