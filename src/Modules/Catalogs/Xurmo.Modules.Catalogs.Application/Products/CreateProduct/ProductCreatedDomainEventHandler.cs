using MediatR;
using Xurmo.Common.Application.EventBus;
using Xurmo.Common.Application.Exceptions;
using Xurmo.Common.Application.Messaging;
using Xurmo.Common.Domain;
using Xurmo.Modules.Catalogs.Application.Products.GetProduct;
using Xurmo.Modules.Catalogs.Domain.Products;
using Xurmo.Modules.Catalogs.IntegrationEvents;

namespace Xurmo.Modules.Catalogs.Application.Products.CreateProduct;
internal sealed class ProductCreatedDomainEventHandler(ISender sender, IEventBus bus)
    : DomainEventHandler<ProductCreatedDomainEvent>
{
    public override async Task Handle(ProductCreatedDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        Result<ProductResponse> result = await sender.Send(
            new GetProductQuery(domainEvent.ProductId),
            cancellationToken);

        if (result.IsFailure)
        {
            throw new XurmoException(nameof(GetProductQuery), result.Error);
        }

        await bus.PublishAsync(
            new ProductCreatedIntegrationEvent(
                domainEvent.Id,
                domainEvent.OccurredOnUtc,
                result.Value.Id,
                result.Value.Name,
                result.Value.Description,
                result.Value.ImagePath),
            cancellationToken);
    }
}
