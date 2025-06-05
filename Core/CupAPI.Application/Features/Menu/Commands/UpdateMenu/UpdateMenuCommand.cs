using CupAPI.Application.Dtos.MenuItemDtos;
using MediatR;

namespace CupAPI.Application.Features.Menu.Commands.UpdateMenu;

public sealed record UpdateMenuCommand(UpdateMenuItemDto UpdateMenuItemDto) : IRequest<ApiResponse<String>>;