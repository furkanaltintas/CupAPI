using CupAPI.Application.Dtos.AuthDtos;
using MediatR;

namespace CupAPI.Application.Features.Customer.Commands.RegisterCustomer;

public sealed record RegisterCustomerCommand(RegisterDto RegisterDto) : IRequest<TokenResponseDto>;
