using CupAPI.Application.Dtos.MenuItemDtos;
using MediatR;

namespace CupAPI.Application.Features.Menu.Commands.CreateMenu;

public sealed record CreateMenuCommand(CreateMenuItemDto CreateMenuItemDto) : IRequest<ApiResponse<String>>
{
}