using Xurmo.Common.Domain;

namespace Xurmo.Modules.Catalogs.Domain.Products;
public static class ProductErrors
{
    public static Error NotFound(Guid productId) =>
        Error.NotFound("Products.NotFound", $"The user with the identifier {productId} not found");
}
