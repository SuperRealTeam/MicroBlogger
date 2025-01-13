// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.


using Mediator;
using MicroBlogger.Application.Common.Models;
using MicroBlogger.Application.Features.Posts.Commands;
using MicroBlogger.Application.Features.Posts.DTOs;
using MicroBlogger.Application.Features.Posts.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MicroBlogger.Api.Endpoints;

public class PostsEndpointRegistar(ILogger<PostsEndpointRegistar> logger) : IEndpointRegistrar
{
    public void RegisterRoutes(IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/posts").WithTags("posts").RequireAuthorization();

        // Get all posts
        group.MapGet("/", async ([FromServices] IMediator mediator) =>
        {
            var query = new GetAllPostsQuery();
            return await mediator.Send(query);
        })
        .Produces<IEnumerable<PostsDto>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Get all posts")
        .WithDescription("Returns a list of all posts in the system.");

        // Create a new post
        group.MapPost("/", ([FromServices] IMediator mediator, [FromBody] CreatePostCommand command) => mediator.Send(command))
             .Produces<PostsDto>(StatusCodes.Status201Created)
            .ProducesValidationProblem(StatusCodes.Status422UnprocessableEntity)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Create a new post")
        .WithDescription("Creates a new post with the provided details.");

        // Get posts with pagination and filtering
        group.MapPost("/pagination", ([FromServices] IMediator mediator, [FromBody] PostsWithPaginationQuery query) => mediator.Send(query))
        .Produces<PaginatedResult<PostsDto>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Get posts with pagination")
        .WithDescription("Returns a paginated list of posts based on search keywords, page size, and sorting options.");
    }
}
