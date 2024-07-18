using Microsoft.AspNetCore.Http;
using Xurmo.Common.Application.Messaging;

namespace Xurmo.Modules.Catalogs.Application.Products.CreateProduct;
public sealed record CreateProductCommand(
    string Name,
    string Description,
    IFormFile Image) : ICommand<Guid>;
