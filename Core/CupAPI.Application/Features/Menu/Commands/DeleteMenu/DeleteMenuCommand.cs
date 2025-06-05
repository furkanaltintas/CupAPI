using MediatR;

namespace CupAPI.Application.Features.Menu.Commands.DeleteMenu;

public sealed record DeleteMenuCommand(int id) : IRequest<ApiResponse<String>>;
