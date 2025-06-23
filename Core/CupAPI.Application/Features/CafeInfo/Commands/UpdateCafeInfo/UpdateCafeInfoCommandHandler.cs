using CupAPI.Application.Services.Concrete;
using MediatR;

namespace CupAPI.Application.Features.CafeInfo.Commands.UpdateCafeInfo;

public sealed class UpdateCafeInfoCommandHandler(CafeInfoService cafeInfoService) : IRequestHandler<UpdateCafeInfoCommand, ApiResponse<String>>
{
    public Task<ApiResponse<string>> Handle(UpdateCafeInfoCommand request, CancellationToken cancellationToken)
    {
        var response = cafeInfoService.UpdateAsync(request.UpdateCafeInfoDto);
        return response;
    }
}
