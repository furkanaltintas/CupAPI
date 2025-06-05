using CupAPI.Application.Dtos.MenuItemDtos;
using MediatR;

namespace CupAPI.Application.Features.Menu.Queries.GetMenuById;

public sealed record GetMenuByIdQuery(int id) : IRequest<ApiResponse<DetailMenuItemDto>>;