using Xurmo.Common.Domain;

namespace Xurmo.Modules.Catalogs.Domain.Products;

public sealed class Product : Entity
{
    private Product() { }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string ImagePath { get; private set; }

    public static Product Create(string name, string description, string imagePath)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            ImagePath = imagePath
        };

        product.Raise(new ProductCreatedDomainEvent(product.Id));

        return product;
    }
}
