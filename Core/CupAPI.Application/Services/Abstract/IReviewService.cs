using CupAPI.Application.Dtos.ReviewDtos;

namespace CupAPI.Application.Services.Abstract;

public interface IReviewService
{
    Task<ApiResponse<List<ResultReviewDto>>> GetAllAsync();
    Task<ApiResponse<DetailReviewDto>> GetByIdAsync(int id);
    Task<ApiResponse<String>> AddAsync(CreateReviewDto createReviewDto);
    Task<ApiResponse<String>> UpdateAsync(UpdateReviewDto updateReviewDto);
    Task<ApiResponse<String>> DeleteAsync(int id);
}
