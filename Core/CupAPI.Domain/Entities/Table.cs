using CupAPI.Domain.Enums;

namespace CupAPI.Domain.Entities;

public sealed class Table : BaseEntity
{
    public TableType Type { get; set; }
    public string TableCode { get; set; } = string.Empty;
    public int TableNumber { get; set; } = 1;
    public int Capacity { get; set; } = 1;

    public List<Order>? Orders { get; set; }
}
