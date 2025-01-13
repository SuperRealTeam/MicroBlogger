// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBlogger.Application.Features.Posts.DTOs;
using MicroBlogger.Application.Features.Posts.EventHandlers;
using MicroBlogger.Application.Features.Products.EventHandlers;
using MicroBlogger.Application.Pipeline;

namespace MicroBlogger.Application.Features.Posts.Commands;
public record CreatePostCommand(string Message,string TempImageUrl, string ImageUrl, double Longtuide, double Latitude) : IFusionCacheRefreshRequest<PostsDto>, IRequiresValidation
{
    public IEnumerable<string>? Tags => new[] { "posts" };
}
public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, PostsDto>
{
    private readonly IApplicationDbContext _context;

    public CreatePostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async ValueTask<PostsDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = new Post
        {
            Message = request.Message,
            ImageUrl = request.ImageUrl??string.Empty,
            TempImageUrl = request.TempImageUrl ?? string.Empty,
            Longtuide = request.Longtuide,
            Latitude = request.Latitude,
        };
        post.AddDomainEvent(new PostCreatedEvent(post));
        _context.Posts.Add(post);
        await _context.SaveChangesAsync(cancellationToken);

        return new PostsDto() { PostId = post.Id, Message = post.Message, Latitude = post.Latitude, Longtuide = post.Longtuide };
    }
}
