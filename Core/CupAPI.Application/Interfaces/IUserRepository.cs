using CupAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CupAPI.Application.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<IdentityResult> AddAsync(AppIdentityUser user, string password);
    Task<AppIdentityUser?> GetByEmailAsync(string email);
    Task<Boolean> ExistsByEmailAsync(string email);
    Task<Boolean> CreateRoleAsync(string roleName);
    Task<Boolean> AddRoleToUserAsync(string email, string roleName);
}