using CupAPI.Application.Dtos.MenuItemDtos;
using MediatR;

namespace CupAPI.Application.Features.Menu.Queries.GetAllMenus;

public sealed record GetAllMenusQuery : IRequest<ApiResponse<List<ResultMenuItemDto>>>;