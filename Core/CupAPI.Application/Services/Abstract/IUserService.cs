using CupAPI.Application.Dtos.AuthDtos;

namespace CupAPI.Application.Services.Abstract;

public interface IUserService
{
    Task<ApiResponse<String>> CreateRole(string roleName);
    Task<ApiResponse<String>> AddRoleToUser(string email, string roleName);
}