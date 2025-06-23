using CupAPI.Application.Dtos.CafeInfoDtos;

namespace CupAPI.Application.Services.Abstract;

public interface ICafeInfoService
{
    Task<ApiResponse<List<ResultCafeInfoDto>>> GetAllAsync();
    Task<ApiResponse<DetailCafeInfoDto>> GetByIdAsync(int id);
    Task<ApiResponse<String>> AddAsync(CreateCafeInfoDto createCafeInfoDto);
    Task<ApiResponse<String>> UpdateAsync(UpdateCafeInfoDto updateCafeInfoDto);
    Task<ApiResponse<String>> DeleteAsync(int id);
}
