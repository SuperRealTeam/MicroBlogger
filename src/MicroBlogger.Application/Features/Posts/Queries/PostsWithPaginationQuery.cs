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

namespace MicroBlogger.Application.Features.Posts.Queries;
public record PostsWithPaginationQuery(string Keywords, int PageNumber = 1, int PageSize = 15, string OrderBy = "Id", string SortDirection = "Descending") : IFusionCacheRequest<PaginatedResult<PostsDto>>
{
    public IEnumerable<string>? Tags => new[] { "posts" };
    public string CacheKey => $"postswithpagination_{Keywords}_{PageNumber}_{PageSize}_{OrderBy}_{SortDirection}";
}

public class PostsWithPaginationQueryHandler : IRequestHandler<PostsWithPaginationQuery, PaginatedResult<PostsDto>>
{
    private readonly IApplicationDbContext _context;

    public PostsWithPaginationQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async ValueTask<PaginatedResult<PostsDto>> Handle(PostsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var data = await _context.Posts.OrderBy(request.OrderBy, request.SortDirection)
                    .ProjectToPaginatedDataAsync(
                        condition: x => x.Message.Contains(request.Keywords),
                        pageNumber: request.PageNumber,
                        pageSize: request.PageSize,
                        mapperFunc: t =>  new PostsDto
                        {
                            PostId = t.Id,
                            Message = t.Message,
                            Created = t.Created.Value.ToString() ?? "",
                            CreatedBy = t.CreatedBy ?? "",
                            ImageUrl = t.ImageUrl,
                            TempImageUrl = t.TempImageUrl,
                        },
                    cancellationToken: cancellationToken);

        return data;
    }
}
