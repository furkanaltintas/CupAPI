using CupAPI.Domain.Enums;

namespace CupAPI.Application.Dtos.TableDtos;

public record CreateTableDto
{
    public TableType Type { get; set; }
    public string TableCode { get; set; } = string.Empty;
    public int TableNumber { get; set; }
    public int Capacity { get; set; }
}