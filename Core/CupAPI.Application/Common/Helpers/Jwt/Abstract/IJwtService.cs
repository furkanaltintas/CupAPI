using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Common.Helpers.Jwt.Abstract;

public interface IJwtService
{
    TokenResponseDto CreateToken(User user);
}