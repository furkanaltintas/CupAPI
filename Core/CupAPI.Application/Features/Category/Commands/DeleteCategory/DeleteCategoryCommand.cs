using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupAPI.Application.Features.Category.Commands.DeleteCategory
{
    public sealed record DeleteCategoryCommand(int id) : IRequest<ApiResponse<String>>;
}