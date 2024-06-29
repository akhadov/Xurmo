using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xurmo.Common.Domain;

namespace Xurmo.Modules.Catalogs.Domain.Products;

public sealed class Product : Entity
{
    public Product() { }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public static Product Create(string name, string description)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description
        };

        return product;
    }
}
