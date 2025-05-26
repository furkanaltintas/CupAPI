namespace CupAPI.Application.Dtos.AuthDtos;

public sealed class TokenResponseDto
{
    public string AccessToken { get; set; } = null!;
    public DateTime Expiration { get; set; }
}