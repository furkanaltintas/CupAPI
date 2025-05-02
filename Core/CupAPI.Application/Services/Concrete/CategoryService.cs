using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Dtos.ResponseDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;
using FluentValidation;

namespace CupAPI.Application.Services.Concrete;

public class CategoryService(
    IGenericRepository<Category> categoryRepository,
    IMapper mapper,
    IValidator<CreateCategoryDto> _createCategoryValidator,
    IValidator<UpdateCategoryDto> _updateCategoryValidator
    ) : ICategoryService
{
    public async Task<ResponseDto<object>> AddCategory(CreateCategoryDto createCategoryDto)
    {
        try
        {
            var validate = await _createCategoryValidator.ValidateAsync(createCategoryDto);
            if (!validate.IsValid) return ResponseDto<object>
                    .Fail(string
                    .Join(" | ", validate.Errors
                    .Select(e => e.ErrorMessage)), ErrorCode.ValidationError);

            Category category = mapper.Map<Category>(createCategoryDto);
            await categoryRepository.AddAsync(category);

            return ResponseDto<object>.SuccessNoDataResult("Kategori oluşturuldu");

        }
        catch (Exception)
        {
            return ResponseDto<object>.Fail("Kategori eklenirken bir hata oluştu", ErrorCode.Exception);
        }
    }

    public async Task<ResponseDto<object>> DeleteCategory(int id)
    {
        try
        {
            Category category = await categoryRepository.GetByIdAsync(id);

            if (category is null) return ResponseDto<object>.Fail("Kategori Bulunamadı", ErrorCode.NotFound);

            await categoryRepository.DeleteAsync(category);
            return ResponseDto<object>.SuccessNoDataResult("Kategori Silindi");
        }
        catch (Exception)
        {
            return ResponseDto<object>.Fail("Kategori getirilirken bir hata oluştu", ErrorCode.Exception);
        }
    }

    public async Task<ResponseDto<List<ResultCategoryDto>>> GetAllCategories()
    {
        try
        {
            List<Category> categories = await categoryRepository.GetAllAsync();

            if (categories is null || !categories.Any()) return ResponseDto<List<ResultCategoryDto>>.Fail("Kategori Bulunamadı", ErrorCode.NotFound);

            List<ResultCategoryDto> dtos = mapper.Map<List<ResultCategoryDto>>(categories);
            return ResponseDto<List<ResultCategoryDto>>.SuccessResult(dtos);
        }
        catch (Exception)
        {
            return ResponseDto<List<ResultCategoryDto>>.Fail("Kategori getirilirken bir hata oluştu", ErrorCode.Exception);
        }
    }

    public async Task<ResponseDto<DetailCategoryDto>> GetByIdCategory(int id)
    {
        try
        {
            Category? category = await categoryRepository.GetByIdAsync(id);
            if (category is null) return ResponseDto<DetailCategoryDto>.Fail("Kategori Bulunamadı", ErrorCode.NotFound);

            DetailCategoryDto detailCategoryDto = mapper.Map<DetailCategoryDto>(category);
            return ResponseDto<DetailCategoryDto>.SuccessResult(detailCategoryDto);
        }
        catch (Exception)
        {
            return ResponseDto<DetailCategoryDto>.Fail("Kategori getirilirken bir hata oluştu", ErrorCode.Exception);
        }
    }

    public async Task<ResponseDto<object>> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        try
        {
            var validate = await _updateCategoryValidator.ValidateAsync(updateCategoryDto);
            if (!validate.IsValid) return ResponseDto<object>
                    .Fail(string
                    .Join(" | ", validate.Errors
                    .Select(e => e.ErrorMessage)), ErrorCode.ValidationError);

            Category category = await categoryRepository.GetByIdAsync(updateCategoryDto.Id);
            if (category is null) return ResponseDto<object>.Fail("Kategori Bulunamadı", ErrorCode.NotFound);

            mapper.Map(updateCategoryDto, category);
            await categoryRepository.UpdateAsync(category);

            return ResponseDto<object>.SuccessNoDataResult("Kategori güncellendi");
        }
        catch (Exception)
        {
            return ResponseDto<object>.Fail("Kategori güncellenirken bir hata oluştu", ErrorCode.Exception);
        }
    }
}
