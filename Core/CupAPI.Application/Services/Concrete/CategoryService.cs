using AutoMapper;
using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Services.Concrete;

public class CategoryService(IGenericRepository<Category> categoryRepository, IMapper mapper) : ICategoryService
{
    public async Task AddCategory(CreateCategoryDto createCategoryDto)
    {
        Category category = mapper.Map<Category>(createCategoryDto);
        await categoryRepository.AddAsync(category);
    }

    public async Task DeleteCategory(int id)
    {
        Category category = await categoryRepository.GetByIdAsync(id);
        await categoryRepository.DeleteAsync(category);
    }

    public async Task<List<ResultCategoryDto>> GetAllCategories()
    {
        List<Category> categories = await categoryRepository.GetAllAsync();
        List<ResultCategoryDto> resultCategoryDtos = mapper.Map<List<ResultCategoryDto>>(categories);
        return resultCategoryDtos;
    }

    public async Task<DetailCategoryDto> GetByIdCategory(int id)
    {
        Category category = await categoryRepository.GetByIdAsync(id);
        DetailCategoryDto detailCategoryDto = mapper.Map<DetailCategoryDto>(category);
        return detailCategoryDto;
    }

    public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        Category category = mapper.Map<Category>(updateCategoryDto);
        await categoryRepository.UpdateAsync(category);
    }
}
