using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;
using CupAPI.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CupAPI.Persistence.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly UserManager<AppIdentityUser> _userManager;
    private readonly RoleManager<AppIdentityRole> _roleManager;
    public UserRepository(AppDbContext context, UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityRole> roleManager) : base(context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<Boolean> ExistsByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user is not null;
    }

    public async Task<AppIdentityUser?> GetByEmailAsync(string email)
    {
        return await _userManager.Users
            .FirstOrDefaultAsync(u => u.Email!.ToLower() == email.ToLower());
    }

    public async Task<IdentityResult> AddAsync(AppIdentityUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<Boolean> CreateRoleAsync(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName)) return false;

        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if (roleExists) return false;

        var result = await _roleManager.CreateAsync(new AppIdentityRole { Name = roleName });
        return result.Succeeded;
    }

    public async Task<Boolean> AddRoleToUserAsync(string email, string roleName)
    {
        // E-posta ile kullanıcıyı bul
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null) return false; // Kullanıcı bulunamadı

        // Rol sistemde tanımlı mı kontrol et
        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if (!roleExists) return false; // Rol tanımlı değil

        // Kullanıcı zaten bu role sahip mi kontrol et (Kullanıcı zaten bu roldeyse tekrar ekleme false dön)
        if (!await _userManager.IsInRoleAsync(user, roleName))
        {
            return false; // Kullanıcı zaten bu role sahip, tekrar ekleme
        }

        // Rolü kullanıcıya ata
        var result = await _userManager.AddToRoleAsync(user, roleName);

        // Eğer işlem başarılıysa true, aksi halde false dön
        return result.Succeeded;
    }
}