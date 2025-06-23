using CupAPI.Application.Dtos.CafeInfoDtos;
using MediatR;

namespace CupAPI.Application.Features.CafeInfo.Queries.GetAllCafeInfos;

public sealed record GetAllCafeInfosQuery : IRequest<ApiResponse<List<ResultCafeInfoDto>>>;