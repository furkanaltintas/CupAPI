using CupAPI.Domain.Enums;

namespace CupAPI.Application.Dtos.TableDtos;

public sealed record CreateTableDto
{
    public TableType Type { get; set; }
    public string TableCode { get; set; }
    public int TableNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsActive { get; set; }
}