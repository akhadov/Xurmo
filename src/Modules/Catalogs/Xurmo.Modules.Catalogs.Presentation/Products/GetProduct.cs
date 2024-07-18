using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Xurmo.Common.Domain;
using Xurmo.Common.Presentation.Endpoints;
using Xurmo.Common.Presentation.Results;
using Xurmo.Modules.Catalogs.Application.Products.GetProduct;

namespace Xurmo.Modules.Catalogs.Presentation.Products;
internal sealed class GetProduct : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("catalogs/products/{id}", async (Guid id, ISender sender) =>
        {
            Result<ProductResponse> result = await sender.Send(new GetProductQuery(id));

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Products)
        .DisableAntiforgery();
    }
}
