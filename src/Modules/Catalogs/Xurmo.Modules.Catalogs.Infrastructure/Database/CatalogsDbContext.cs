using Microsoft.EntityFrameworkCore;
using Xurmo.Common.Infrastructure.Inbox;
using Xurmo.Common.Infrastructure.Outbox;
using Xurmo.Modules.Catalogs.Application.Abstractions.Data;
using Xurmo.Modules.Catalogs.Domain.Products;
using Xurmo.Modules.Catalogs.Infrastructure.Products;

namespace Xurmo.Modules.Catalogs.Infrastructure.Database;

public sealed class CatalogsDbContext(DbContextOptions<CatalogsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Catalogs);

        modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());
        modelBuilder.ApplyConfiguration(new OutboxMessageConsumerConfiguration());
        modelBuilder.ApplyConfiguration(new InboxMessageConfiguration());
        modelBuilder.ApplyConfiguration(new InboxMessageConsumerConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}
