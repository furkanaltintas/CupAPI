using CupAPI.Application.Dtos.UserDtos;
using CupAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CupAPI.Application.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<SignInResult> LoginAsync(LoginDto loginDto, User user);
    Task LogoutAsync();
}