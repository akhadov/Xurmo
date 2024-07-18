namespace Xurmo.Modules.Catalogs.Application.Products.GetProduct;
public sealed record ProductResponse(
    Guid Id,
    string Name,
    string Description,
    string ImagePath);
