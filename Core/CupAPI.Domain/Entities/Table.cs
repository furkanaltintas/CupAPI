using CupAPI.Domain.Enums;

namespace CupAPI.Domain.Entities;

public sealed class Table
{
    public int Id { get; set; }
    public TableType Type { get; set; }
    public string TableCode { get; set; } = string.Empty;
    public int TableNumber { get; set; } = 1;
    public int Capacity { get; set; } = 1;
    public bool IsActive { get; set; } = false;
}
