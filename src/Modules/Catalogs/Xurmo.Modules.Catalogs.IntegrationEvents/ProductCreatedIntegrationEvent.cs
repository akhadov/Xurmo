using Xurmo.Common.Application.EventBus;

namespace Xurmo.Modules.Catalogs.IntegrationEvents;

public class ProductCreatedIntegrationEvent : IntegrationEvent
{
    public ProductCreatedIntegrationEvent(
        Guid id,
        DateTime occurredOnUtc,
        Guid productId,
        string name,
        string description,
        string imagepath)
        : base(id, occurredOnUtc)
    {
        ProductId = productId;
        Name = name;
        Description = description;
        ImagePath = imagepath;
    }

    public Guid ProductId { get; init; }

    public string Name { get; init; }

    public string Description { get; init; }

    public string ImagePath { get; init; }
}
