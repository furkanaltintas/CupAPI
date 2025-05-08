using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Domain.Entities;
using AutoMapper;

namespace CupAPI.Application.Mappings;

public sealed class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, DetailCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember is not null));

        CreateMap<MenuItem, ResultMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, DetailMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, CreateMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, UpdateMenuItemDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember is not null));

        CreateMap<Table, ResultTableDto>().ReverseMap();
        CreateMap<Table, DetailTableDto>().ReverseMap();
        CreateMap<Table, CreateTableDto>().ReverseMap();
        CreateMap<Table, UpdateTableDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember is not null));
    }
}