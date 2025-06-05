using CupAPI.Application.Dtos.TableDtos;
using MediatR;

namespace CupAPI.Application.Features.Table.Commands.CreateTable;

public sealed record CreateTableCommand(CreateTableDto CreateTableDto) : IRequest<ApiResponse<String>>;