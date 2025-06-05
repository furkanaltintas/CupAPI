using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CupAPI.Application.Services.Abstract;

public interface IUserService
{
    Task<bool> EmailExistsAsync(string email);
    Task<AppIdentityUser?> GetByEmailAsync(string email);
    Task<IdentityResult> CreateUserAsync(RegisterDto dto);
    Task<bool> AssignRoleAsync(string email, string role);
}