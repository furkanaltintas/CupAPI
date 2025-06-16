using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Customer.Commands.RegisterCustomer;

public sealed class RegisterCustomerCommandHandler(IAuthService authService) : IRequestHandler<RegisterCustomerCommand, TokenResponseDto>
{
    public async Task<TokenResponseDto> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        return await authService.RegisterCustomerAsync(request.RegisterDto);
    }
}