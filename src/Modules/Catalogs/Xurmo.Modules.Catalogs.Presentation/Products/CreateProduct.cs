using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Xurmo.Common.Domain;
using Xurmo.Common.Presentation.Endpoints;
using Xurmo.Common.Presentation.Results;
using Xurmo.Modules.Catalogs.Application.Products.CreateProduct;

namespace Xurmo.Modules.Catalogs.Presentation.Products;
internal sealed class CreateProduct : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("catalogs", async (Request request, ISender sender) =>
        {
            Result<Guid> result = await sender.Send(new CreateProductCommand(request.Name, request.Description));

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Products);
    }

    internal sealed class Request
    {
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
