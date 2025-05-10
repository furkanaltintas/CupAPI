using AutoMapper;
using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Common.Helpers;
using CupAPI.Application.Common.Rules.TableRules;
using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;
using CupAPI.Domain.Enums;

namespace CupAPI.Application.Services.Concrete;

public class TableService(
    IGenericRepository<Table> tableRepository,
    ITableRepository repository,
    IMapper mapper,
    IValidationHelper validationHelper,
    TableBusinessRules tableBusinessRules) : ITableService
{
    public async Task<ApiResponse<String>> AddAsync(CreateTableDto createTableDto)
    {
        try
        {
            var response = await validationHelper.ValidateAsync<CreateTableDto, String>(createTableDto);
            if (!response.Success) return response;

            Table table = mapper.Map<Table>(createTableDto);
            await tableRepository.AddAsync(table);
            await tableRepository.SaveChangesAsync();
            return ApiResponse<String>.SuccessNoDataResult(Messages.Table.Created);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Table.ErrorWhileAdding, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<String>> DeleteAsync(int id)
    {
        try
        {
            var response = await tableBusinessRules.TableShouldExist(id);
            if (!response.Success) return ApiResponse<String>.Fail(response.Message, response.ErrorCode);

            tableRepository.Delete(response.Data!);
            await tableRepository.SaveChangesAsync();
            return ApiResponse<String>.SuccessNoDataResult(Messages.Table.Deleted);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Table.ErrorWhileDeleting, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<List<ResultTableDto>>> GetAllAsync()
    {
        try
        {
            List<Table> tables = await tableRepository.GetAllAsync();
            if (tables is null || !tables.Any()) return ApiResponse<List<ResultTableDto>>.SuccessEmptyDataResult(new(), Messages.General.DataIsEmpty, ErrorCodeEnum.EmptyData);

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
            Table? table = await repository.GetByCodeAsync(tableCode);
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
            var response = await tableBusinessRules.TableShouldExist(id);
            if (!response.Success) return ApiResponse<DetailTableDto>.Fail(response.Message, response.ErrorCode);

            DetailTableDto detailTableDto = mapper.Map<DetailTableDto>(response.Data!);
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
            Table? table = await repository.GetByNumberAsync(tableNumber);
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
            Table? table = await repository.GetByTypeAsync(tableType);
            if (table is null) return ApiResponse<DetailTableDto>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            DetailTableDto detailTableDto = mapper.Map<DetailTableDto>(table);
            return ApiResponse<DetailTableDto>.SuccessResult(detailTableDto);
        }
        catch
        {
            return ApiResponse<DetailTableDto>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<String>> UpdateAsync(UpdateTableDto updateTableDto)
    {
        try
        {
            var validateResponse = await validationHelper.ValidateAsync<UpdateTableDto, String>(updateTableDto);
            if (!validateResponse.Success) return validateResponse;

            var businessResponse = await tableBusinessRules.TableShouldExist(updateTableDto.Id);
            if (!businessResponse.Success) return ApiResponse<String>.Fail(businessResponse.Message, businessResponse.ErrorCode);

            if (businessResponse.Data is null) return ApiResponse<String>.Fail(Messages.MenuItem.NotFound, ErrorCodeEnum.NotFound);

            mapper.Map(updateTableDto, businessResponse.Data!);
            tableRepository.Update(businessResponse.Data!);
            await tableRepository.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.Table.Updated);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Table.ErrorWhileUpdating, ErrorCodeEnum.Exception);
        }
    }
}