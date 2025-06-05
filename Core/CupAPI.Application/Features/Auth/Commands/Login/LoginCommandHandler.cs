using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler(IAuthService authService) : IRequestHandler<LoginCommand, TokenResponseDto>
{
    public async Task<TokenResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await authService.LoginAsync(request.LoginDto);
    }
}