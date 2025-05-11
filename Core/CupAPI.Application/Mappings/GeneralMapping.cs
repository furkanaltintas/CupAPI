using AutoMapper;
using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Dtos.OrderDtos;
using CupAPI.Application.Dtos.OrderItemDtos;
using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Mappings;

public sealed class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateBidirectionalMaps<Category, ResultCategoryDto, DetailCategoryDto, CreateCategoryDto, UpdateCategoryDto>();
        CreateBidirectionalMaps<MenuItem, ResultMenuItemDto, DetailMenuItemDto, CreateMenuItemDto, UpdateMenuItemDto>();
        CreateBidirectionalMaps<Table, ResultTableDto, DetailTableDto, CreateTableDto, UpdateTableDto>();
        CreateBidirectionalMaps<Order, ResultOrderDto, DetailOrderDto, CreateOrderDto, UpdateOrderDto>();
        CreateBidirectionalMaps<OrderItem, ResultOrderItemDto, DetailOrderItemDto, CreateOrderItemDto, UpdateOrderItemDto>();
    }

    private void CreateBidirectionalMaps<TEntity, TResultDto, TDetailDto, TCreateDto, TUpdateDto>()
    {
        CreateMap<TEntity, TResultDto>().ReverseMap();
        CreateMap<TEntity, TDetailDto>().ReverseMap();
        CreateMap<TEntity, TCreateDto>().ReverseMap();
        CreateMap<TEntity, TUpdateDto>()
            .ReverseMap()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember is not null));
    }
}