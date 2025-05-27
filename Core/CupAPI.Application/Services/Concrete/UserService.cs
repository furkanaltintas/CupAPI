using CupAPI.Application.Common.Enums;
using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using FluentValidation;

namespace CupAPI.Application.Services.Concrete;

public class UserService(
    IUserRepository userRepository) : IUserService
{
    public async Task<ApiResponse<string>> AddRoleToUser(string email, string roleName)
    {
        try
        {
            var result = await userRepository.AddRoleToUserAsync(email, roleName);
            if(!result) return ApiResponse<string>.Fail("User not found or role does not exist.", ErrorCodeEnum.NotFound);

            return ApiResponse<String>.SuccessNoDataResult("Role added to user successfully.");
        }
        catch
        {
            return ApiResponse<string>.Fail("Failed to add role to user.", ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<string>> CreateRole(string roleName)
    {
        try
        {
            var result = await userRepository.CreateRoleAsync(roleName);
            if(!result) return ApiResponse<String>.Fail("Role already exists or invalid role name.", ErrorCodeEnum.NotFound);

            return ApiResponse<String>.SuccessNoDataResult("Role created successfully.");
        }
        catch
        {
            return ApiResponse<String>.Fail("Role creation failed.", ErrorCodeEnum.Exception);
        }
    }
