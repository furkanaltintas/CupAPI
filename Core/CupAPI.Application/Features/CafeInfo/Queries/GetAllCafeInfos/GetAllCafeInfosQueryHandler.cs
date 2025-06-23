using CupAPI.Application.Dtos.CafeInfoDtos;
using CupAPI.Application.Services.Concrete;
using MediatR;

namespace CupAPI.Application.Features.CafeInfo.Queries.GetAllCafeInfos;

public sealed class GetAllCafeInfosQueryHandler(CafeInfoService cafeInfoService) : IRequestHandler<GetAllCafeInfosQuery, ApiResponse<List<ResultCafeInfoDto>>>
{
    public async Task<ApiResponse<List<ResultCafeInfoDto>>> Handle(GetAllCafeInfosQuery request, CancellationToken cancellationToken)
    {
        var response = await cafeInfoService.GetAllAsync();
        return response;
    }
}