using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;
using CupAPI.Persistence.Context;
using CupAPI.Persistence.Context.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CupAPI.Persistence.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly UserManager<AppIdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public UserRepository(AppDbContext context, UserManager<AppIdentityUser> userManager, RoleManager<IdentityRole> roleManager) : base(context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.Users
            .AnyAsync(u => u.Email.ToLower() == email.ToLower());
    }

    public async Task<bool> CreateRoleAsync(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName)) return false;

        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if (roleExists) return false;

        var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
        if (result.Succeeded) return true;
        return false;
    }

    public async Task<bool> AddRoleToUserAsync(string email, string roleName)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null) return false;

        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if (!roleExists) return false;

        var result = await _userManager.AddToRoleAsync(user, roleName);
        if (result.Succeeded) return true;
        return false;
    }
}