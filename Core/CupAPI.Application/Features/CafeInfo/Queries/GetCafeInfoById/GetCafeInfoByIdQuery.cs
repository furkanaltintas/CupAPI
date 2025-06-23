using CupAPI.Application.Dtos.CafeInfoDtos;
using MediatR;

namespace CupAPI.Application.Features.CafeInfo.Queries.GetCafeInfoById;

public sealed record GetCafeInfoByIdQuery(int Id) : IRequest<ApiResponse<DetailCafeInfoDto>>;