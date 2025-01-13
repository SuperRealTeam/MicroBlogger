using System.Globalization;
using MicroBlogger.Application.Features.Products.DTOs;
using MicroBlogger.Application.Features.Products.EventHandlers;
using MicroBlogger.Application.Pipeline;
using CsvHelper;

namespace MicroBlogger.Application.Features.Products.Commands;
public record ImportProductsCommand(Stream Stream
) : IFusionCacheRefreshRequest<Unit>, IRequiresValidation
{
    public IEnumerable<string>? Tags => new[] { "products" };
}

public class ImportProductsCommandHandler : IRequestHandler<ImportProductsCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public ImportProductsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async ValueTask<Unit> Handle(ImportProductsCommand request, CancellationToken cancellationToken)
    {
        request.Stream.Position = 0;
        using (var reader = new StreamReader(request.Stream))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<ProductDto>();
            foreach (var product in records.Select(x=>new Product()
            {
                SKU = x.SKU,
                Name = x.Name,
                Category = (ProductCategory)x.Category,
                Description = x.Description,
                Price = x.Price,
                Currency = x.Currency,
                UOM = x.UOM
            }))
            {
                product.AddDomainEvent(new ProductCreatedEvent(product));
                _context.Products.Add(product);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
