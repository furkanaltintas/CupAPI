namespace CupAPI.Domain.Entities;

public sealed class Review : BaseEntity
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}
