using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.CafeInfo.Commands.CreateCafeInfo;

public sealed class CreateCafeInfoCommandHandler(ICafeInfoService cafeInfoService) : IRequestHandler<CreateCafeInfoCommand, ApiResponse<String>>
{
    public async Task<ApiResponse<String>> Handle(CreateCafeInfoCommand request, CancellationToken cancellationToken)
    {
        var result = await cafeInfoService.AddAsync(request.CreateCafeInfoDto);
        return result;
    }
}
