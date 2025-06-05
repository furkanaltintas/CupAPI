using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CupAPI.Application.Services.Concrete;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<bool> EmailExistsAsync(string email)
    {
        return await userRepository.ExistsByEmailAsync(email);
    }

    public async Task<AppIdentityUser?> GetByEmailAsync(string email)
    {
        return await userRepository.GetByEmailAsync(email);
    }

    public async Task<IdentityResult> CreateUserAsync(RegisterDto dto)
    {
        var user = new AppIdentityUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            PhoneNumber = dto.Phone,
            Name = dto.Name,
            Surname = dto.Surname
        };

        return await userRepository.AddAsync(user, dto.Password);
    }

    public async Task<bool> AssignRoleAsync(string email, string role)
    {
        return await userRepository.AddRoleToUserAsync(email, role);
    }
}
