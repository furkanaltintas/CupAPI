namespace CupAPI.Application.Dtos.CafeInfoDtos;

public class CreateCafeInfoDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? WebSiteUrl { get; set; } = string.Empty;
    public string? InstagramUrl { get; set; } = string.Empty;
    public string? YoutubeUrl { get; set; } = string.Empty;
    public string? FacebookUrl { get; set; } = string.Empty;
    public string? TwitterUrl { get; set; } = string.Empty;
    public string OpeningHours { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}