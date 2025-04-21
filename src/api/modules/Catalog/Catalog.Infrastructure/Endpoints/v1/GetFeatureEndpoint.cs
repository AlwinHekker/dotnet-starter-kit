using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Features.Get.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class GetFeatureEndpoint
{
    internal static RouteHandlerBuilder MapGetFeatureEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetFeatureRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetFeatureEndpoint))
            .WithSummary("gets feature by id")
            .WithDescription("gets feature by id")
            .Produces<FeatureResponse>()
            .RequirePermission("Permissions.Features.View")
            .MapToApiVersion(1);
    }
}
