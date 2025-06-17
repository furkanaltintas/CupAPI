using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;
using CupAPI.Persistence.Context;

namespace CupAPI.Persistence.Repository;

public class CafeInfoRepository : GenericRepository<CafeInfo>, ICafeInfoRepository
{
    public CafeInfoRepository(AppDbContext context) : base(context)
    {
    }
}
