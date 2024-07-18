using Xurmo.Common.Application.Messaging;

namespace Xurmo.Modules.Catalogs.Application.Products.GetProduct;
public sealed record GetProductQuery(Guid ProductId) : IQuery<ProductResponse>;
