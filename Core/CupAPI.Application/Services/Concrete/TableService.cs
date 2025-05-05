using CupAPI.Application.Services.Abstract;
using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Responses;
using CupAPI.Application.Common.Helpers;
using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;
using CupAPI.Domain.Enums;
using FluentValidation;
using AutoMapper;

namespace CupAPI.Application.Services.Concrete;

public class TableService(
    IGenericRepository<Table> tableRepository,
    IMapper mapper,
    IValidator<CreateTableDto> createTableValidator,
    IValidator<UpdateTableDto> updateTableValidator) : ITableService
{
    public async Task<ApiResponse<object>> AddAsync(CreateTableDto createTableDto)
    {
        try
        {
            var response = await ValidationHelper.ValidateAsync(createTableValidator, createTableDto);
            if (!response.Success) return response;

            Table table = mapper.Map<Table>(createTableDto);
            await tableRepository.AddAsync(table);
            return ApiResponse<object>.SuccessNoDataResult(Messages.Table.Created);
        }
        catch
        {
            return ApiResponse<object>.Fail(Messages.Table.ErrorWhileAdding, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<object>> DeleteAsync(int id)
    {
        try
        {
            Table table = await tableRepository.GetByIdAsync(id);

            if (table is null) return ApiResponse<object>.Fail(Messages.Table.NotFound, ErrorCodeEnum.NotFound);

            await tableRepository.DeleteAsync(table);
            return ApiResponse<object>.SuccessNoDataResult(Messages.Table.Deleted);
        }
        catch
        {
            return ApiResponse<object>.Fail(Messages.Table.ErrorWhileDeleting, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<List<ResultTableDto>>> GetAllAsync()
    {
        try
        {
            List<Table> tables = await tableRepository.GetAllAsync();

            if (tables is null || !tables.Any()) return ApiResponse<List<ResultTableDto>>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            List<ResultTableDto> dtos = mapper.Map<List<ResultTableDto>>(tables);
            return ApiResponse<List<ResultTableDto>>.SuccessResult(dtos);
        }
        catch
        {
            return ApiResponse<List<ResultTableDto>>.Fail(Messages.Table.ErrorWhileFetching, Common.Enums.ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<DetailTableDto>> GetByCodeAsync(string tableCode)
    {
        try
        {
            Table? table = await tableRepository.GetByIdAsync(1); // GÜNCELLENECEK
            if (table is null) return ApiResponse<DetailTableDto>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            DetailTableDto detailTableDto = mapper.Map<DetailTableDto>(table);
            return ApiResponse<DetailTableDto>.SuccessResult(detailTableDto);
        }
        catch
        {
            return ApiResponse<DetailTableDto>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<DetailTableDto>> GetByIdAsync(int id)
    {
        try
        {
            Table? table = await tableRepository.GetByIdAsync(id);
            if (table is null) return ApiResponse<DetailTableDto>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            DetailTableDto detailTableDto = mapper.Map<DetailTableDto>(table);
            return ApiResponse<DetailTableDto>.SuccessResult(detailTableDto);
        }
        catch
        {
            return ApiResponse<DetailTableDto>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<DetailTableDto>> GetByNumberAsync(int tableNumber)
    {
        try
        {
            Table? table = await tableRepository.GetByIdAsync(1); // GÜNCELLENECEK
            if (table is null) return ApiResponse<DetailTableDto>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            DetailTableDto detailTableDto = mapper.Map<DetailTableDto>(table);
            return ApiResponse<DetailTableDto>.SuccessResult(detailTableDto);
        }
        catch
        {
            return ApiResponse<DetailTableDto>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<DetailTableDto>> GetByTypeAsync(TableType tableType)
    {
        try
        {
            Table? table = await tableRepository.GetByIdAsync(1); // GÜNCELLENECEK
            if (table is null) return ApiResponse<DetailTableDto>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            DetailTableDto detailTableDto = mapper.Map<DetailTableDto>(table);
            return ApiResponse<DetailTableDto>.SuccessResult(detailTableDto);
        }
        catch
        {
            return ApiResponse<DetailTableDto>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<object>> UpdateAsync(UpdateTableDto updateTableDto)
    {
        try
        {
            var response = await ValidationHelper.ValidateAsync(updateTableValidator, updateTableDto);
            if (!response.Success) return response;

            Table table = await tableRepository.GetByIdAsync(updateTableDto.Id);
            if (table is null) return ApiResponse<object>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            mapper.Map(updateTableDto, table);
            await tableRepository.UpdateAsync(table);

            return ApiResponse<object>.SuccessNoDataResult(Messages.Table.Updated);
        }
        catch
        {
            return ApiResponse<object>.Fail(Messages.Table.ErrorWhileUpdating, ErrorCodeEnum.Exception);
        }
    }
}
