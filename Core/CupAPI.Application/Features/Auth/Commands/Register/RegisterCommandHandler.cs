using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler(IAuthService authService) : IRequestHandler<RegisterCommand, TokenResponseDto>
{
    public async Task<TokenResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return await authService.RegisterAsync(request.RegisterDto);
    }
}