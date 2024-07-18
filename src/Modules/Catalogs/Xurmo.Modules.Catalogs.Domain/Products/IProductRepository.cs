namespace Xurmo.Modules.Catalogs.Domain.Products;
public interface IProductRepository
{
    public Task<Product?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Product product);
}
