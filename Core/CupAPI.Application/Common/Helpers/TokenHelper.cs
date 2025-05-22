using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CupAPI.Application.Dtos.AuthDtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CupAPI.Application.Common.Helpers;

public sealed class TokenHelper(IConfiguration configuration)
{
    public async Task<String> GenerateToken(TokenDto tokenDto)
    {
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

        Claim[] claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, tokenDto.Id),
            new Claim(ClaimTypes.Email, tokenDto.Email),
            new Claim(ClaimTypes.Role, tokenDto.Role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        JwtSecurityToken token = new(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: credentials
            );

        String resultToken = new JwtSecurityTokenHandler().WriteToken(token);
        return resultToken;
    }
}