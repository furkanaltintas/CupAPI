using MediatR;

namespace CupAPI.Application.Features.Table.Commands.DeleteTable;

public sealed record DeleteTableCommand(int id) : IRequest<ApiResponse<String>>;