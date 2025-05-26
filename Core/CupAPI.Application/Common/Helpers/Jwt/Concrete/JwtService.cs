using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CupAPI.Application.Common.Helpers.Jwt.Abstract;
using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CupAPI.Application.Common.Helpers.Jwt.Concrete;

public sealed class JwtService(IConfiguration configuration) : IJwtService
{
    public TokenResponseDto CreateToken(User user)
    {
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

        DateTime expires = DateTime.UtcNow.AddHours(2);

        Claim[] claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.AppUserId),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        JwtSecurityToken token = new(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: credentials
            );

        return new TokenResponseDto
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expires
        };
    }
}
