using CupAPI.Application.Dtos.AuthDtos;
using MediatR;

namespace CupAPI.Application.Features.Auth.Commands.Register;

public sealed record RegisterCommand(RegisterDto RegisterDto) : IRequest<TokenResponseDto>;