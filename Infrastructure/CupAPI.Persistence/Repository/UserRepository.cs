using CupAPI.Application.Dtos.UserDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;
using CupAPI.Persistence.Context;
using CupAPI.Persistence.Context.Identity;
using Microsoft.AspNetCore.Identity;

namespace CupAPI.Persistence.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;

        public UserRepository(AppDbContext context, UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager) : base(context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> LoginAsync(LoginDto loginDto, AppIdentityUser user)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
