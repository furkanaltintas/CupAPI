using CupAPI.Application.Dtos.CafeInfoDtos;
using MediatR;

namespace CupAPI.Application.Features.CafeInfo.Commands.CreateCafeInfo;

public sealed record CreateCafeInfoCommand(CreateCafeInfoDto CreateCafeInfoDto) : IRequest<ApiResponse<String>>;
