using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Features.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class UpdateFeatureEndpoint
{
    internal static RouteHandlerBuilder MapFeatureUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateFeatureCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateFeatureEndpoint))
            .WithSummary("update a feature")
            .WithDescription("update a feature")
            .Produces<UpdateFeatureResponse>()
            .RequirePermission("Permissions.Features.Update")
            .MapToApiVersion(1);
    }
}
