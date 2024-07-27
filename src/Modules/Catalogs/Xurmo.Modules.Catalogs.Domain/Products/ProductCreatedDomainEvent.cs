using Xurmo.Common.Domain;

namespace Xurmo.Modules.Catalogs.Domain.Products;
public sealed class ProductCreatedDomainEvent(Guid productId) : DomainEvent
{
    public Guid ProductId { get; init; } = productId;
}
