using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.ReviewDtos;
using CupAPI.Application.Features.Review.Commands.CreateReview;
using CupAPI.Application.Features.Review.Commands.DeleteReview;
using CupAPI.Application.Features.Review.Commands.UpdateReview;
using CupAPI.Application.Features.Review.Queries.GetAllReviews;
using CupAPI.Application.Features.Review.Queries.GetReviewById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthorizationPolicy = CupAPI.Domain.Enums.AuthorizationPolicy;

namespace CupAPI.API.Controllers;

public class ReviewsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await Mediator.Send(new GetAllReviewsQuery());
        return HandleResponse(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await Mediator.Send(new GetReviewByIdQuery(id));
        return HandleResponse(response);
    }

    [Authorize(Policy = AuthorizationPolicy.AdminOnly)]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateReviewDto createReviewDto)
    {
        var response = await Mediator.Send(new CreateReviewCommand(createReviewDto));
        return HandleResponse(response);
    }

    [Authorize(Policy = AuthorizationPolicy.AdminOnly)]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateReviewDto updateReviewDto)
    {
        var response = await Mediator.Send(new UpdateReviewCommand(updateReviewDto));
        return HandleResponse(response);
    }

    [Authorize(Policy = AuthorizationPolicy.AdminOnly)]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await Mediator.Send(new DeleteReviewCommand(id));
        return HandleResponse(response);
    }
}