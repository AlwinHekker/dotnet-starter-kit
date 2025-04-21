using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Features.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class CreateFeatureEndpoint
{
    internal static RouteHandlerBuilder MapFeatureCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateFeatureCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateFeatureEndpoint))
            .WithSummary("creates a feature")
            .WithDescription("creates a feature")
            .Produces<CreateFeatureResponse>()
            .RequirePermission("Permissions.Features.Create")
            .MapToApiVersion(1);
    }
}
