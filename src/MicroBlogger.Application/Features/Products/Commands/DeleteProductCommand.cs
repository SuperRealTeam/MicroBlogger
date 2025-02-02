﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MicroBlogger.Application.Features.Products.EventHandlers;
using MicroBlogger.Application.Pipeline;

namespace MicroBlogger.Application.Features.Products.Commands;
public record DeleteProductCommand(params IEnumerable<string> Ids) : IFusionCacheRefreshRequest<Unit>, IRequiresValidation
{
    public IEnumerable<string>? Tags => new[] { "products" };
}


public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> logger, IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var products = _dbContext.Products.Where(p => request.Ids.Contains(p.Id));
        foreach (var product in products)
        {
            product.AddDomainEvent(new ProductDeletedEvent(product));
            _dbContext.Products.Remove(product);
        }
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
