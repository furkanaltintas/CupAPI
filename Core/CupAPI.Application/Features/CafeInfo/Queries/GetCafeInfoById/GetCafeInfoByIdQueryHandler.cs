using CupAPI.Application.Dtos.CafeInfoDtos;
using CupAPI.Application.Services.Concrete;
using MediatR;

namespace CupAPI.Application.Features.CafeInfo.Queries.GetCafeInfoById
{
    public sealed class GetCafeInfoByIdQueryHandler(CafeInfoService cafeInfoService) : IRequestHandler<GetCafeInfoByIdQuery, ApiResponse<DetailCafeInfoDto>>
    {
        public Task<ApiResponse<DetailCafeInfoDto>> Handle(GetCafeInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var response = cafeInfoService.GetByIdAsync(request.Id);
            return response;
        }
    }
}