using Microsoft.AspNetCore.Routing;

namespace Xurmo.Common.Presentation.Endpoints;
public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
