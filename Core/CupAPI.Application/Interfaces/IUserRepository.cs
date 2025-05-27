using CupAPI.Domain.Entities;

namespace CupAPI.Application.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task AddAsync(User user);
    Task<User?> GetByEmailAsync(string email);
    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> CreateRoleAsync(string roleName);
    Task<bool> AddRoleToUserAsync(string email, string roleName);
}