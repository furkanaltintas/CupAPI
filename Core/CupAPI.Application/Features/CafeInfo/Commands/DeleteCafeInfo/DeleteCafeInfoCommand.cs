using MediatR;

namespace CupAPI.Application.Features.CafeInfo.Commands.DeleteCafeInfo;

public sealed record DeleteCafeInfoCommand(int Id) : IRequest<ApiResponse<String>>;