namespace CupAPI.Application.Dtos.ReviewDtos;

public class CreateReviewDto
{
    public string UserId { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
}