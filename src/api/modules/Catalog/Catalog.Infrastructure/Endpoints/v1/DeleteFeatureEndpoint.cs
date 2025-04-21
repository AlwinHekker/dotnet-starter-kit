using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Features.Delete.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class DeleteFeatureEndpoint
{
    internal static RouteHandlerBuilder MapFeatureDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
             {
                 await mediator.Send(new DeleteFeatureCommand(id));
                 return Results.NoContent();
             })
            .WithName(nameof(DeleteFeatureEndpoint))
            .WithSummary("deletes feature by id")
            .WithDescription("deletes feature by id")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Features.Delete")
            .MapToApiVersion(1);
    }
}
