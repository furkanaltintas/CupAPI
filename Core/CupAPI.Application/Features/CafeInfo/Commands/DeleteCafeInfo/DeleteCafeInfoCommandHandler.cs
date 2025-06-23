using CupAPI.Application.Services.Concrete;
using MediatR;

namespace CupAPI.Application.Features.CafeInfo.Commands.DeleteCafeInfo;

public sealed class DeleteCafeInfoCommandHandler(CafeInfoService cafeInfoService) : IRequestHandler<DeleteCafeInfoCommand, ApiResponse<String>>
{
    public Task<ApiResponse<string>> Handle(DeleteCafeInfoCommand request, CancellationToken cancellationToken)
    {
        var response = cafeInfoService.DeleteAsync(request.Id);
        return response;
    }
}