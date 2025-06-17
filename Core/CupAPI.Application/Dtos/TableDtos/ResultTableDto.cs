using CupAPI.Domain.Enums;

namespace CupAPI.Application.Dtos.TableDtos;

public record ResultTableDto : CreateTableDto
{
    public int Id { get; set; }
}