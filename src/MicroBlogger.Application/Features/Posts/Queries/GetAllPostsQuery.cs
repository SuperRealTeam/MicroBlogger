// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBlogger.Application.Features.Posts.DTOs;
using MicroBlogger.Application.Features.Products.DTOs;
using MicroBlogger.Application.Features.Products.Queries;

namespace MicroBlogger.Application.Features.Posts.Queries;
public record GetAllPostsQuery : IFusionCacheRequest<List<PostsDto>>
{
    public string CacheKey => "getallposts";
    public IEnumerable<string>? Tags => new[] { "posts" };
}
public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, List<PostsDto>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetAllPostsQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<List<PostsDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await _dbContext.Posts.OrderByDescending(x => x.Created)
            .Select(t => new PostsDto
            {
                PostId = t.Id,
                Message = t.Message,
                Created = t.Created.Value.ToString() ?? "",
                CreatedBy =t.CreatedBy ?? "",
                ImageUrl = t.ImageUrl,
                TempImageUrl = t.TempImageUrl,

            })
            .ToListAsync(cancellationToken);

        return posts;
    }
}
