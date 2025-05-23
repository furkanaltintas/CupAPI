using Microsoft.AspNetCore.Identity;

namespace CupAPI.Persistence.Context.Identity;

public sealed class AppIdentityUser : IdentityUser
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
}