using CupAPI.Application.Dtos.AuthDtos;
using MediatR;

namespace CupAPI.Application.Features.Auth.Commands.Login;

public sealed record LoginCommand(LoginDto LoginDto) : IRequest<TokenResponseDto>;