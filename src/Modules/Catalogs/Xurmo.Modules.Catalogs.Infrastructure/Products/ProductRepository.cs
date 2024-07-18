using Microsoft.EntityFrameworkCore;
using Xurmo.Modules.Catalogs.Domain.Products;
using Xurmo.Modules.Catalogs.Infrastructure.Database;

namespace Xurmo.Modules.Catalogs.Infrastructure.Products;
internal sealed class ProductRepository(CatalogsDbContext context) : IProductRepository
{
    public async Task<Product?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Products.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public void Insert(Product product)
    {
        context.Products.Add(product);
    }
}
