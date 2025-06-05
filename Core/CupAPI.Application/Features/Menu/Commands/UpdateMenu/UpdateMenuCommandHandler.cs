using MediatR;

namespace CupAPI.Application.Features.Menu.Commands.UpdateMenu;

public sealed class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, ApiResponse<String>>
{
    public Task<ApiResponse<string>> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
