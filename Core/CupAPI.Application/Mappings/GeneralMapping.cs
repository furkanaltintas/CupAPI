using AutoMapper;
using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Mappings;

internal class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, DetailCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember is not null));

        CreateMap<MenuItem, ResultMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, DetailMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, CreateMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, UpdateMenuItemDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember is not null));
    }
}