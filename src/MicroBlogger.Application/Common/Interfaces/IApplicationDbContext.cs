namespace MicroBlogger.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Post> Posts { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<AuditTrail> AuditTrails { get; set; }
    DbSet<Tenant> Tenants { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
}

