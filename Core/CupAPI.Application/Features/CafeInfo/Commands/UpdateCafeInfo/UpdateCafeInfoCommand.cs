using CupAPI.Application.Dtos.CafeInfoDtos;
using MediatR;

namespace CupAPI.Application.Features.CafeInfo.Commands.UpdateCafeInfo;

public sealed record UpdateCafeInfoCommand(UpdateCafeInfoDto UpdateCafeInfoDto) : IRequest<ApiResponse<String>>;