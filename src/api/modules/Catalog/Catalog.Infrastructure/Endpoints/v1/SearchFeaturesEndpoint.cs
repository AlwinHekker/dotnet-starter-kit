using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Features.Get.v1;
using FSH.Starter.WebApi.Catalog.Application.Features.Search.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;

public static class SearchFeaturesEndpoint
{
    internal static RouteHandlerBuilder MapGetFeatureListEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async (ISender mediator, [FromBody] SearchFeaturesCommand command) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchFeaturesEndpoint))
            .WithSummary("Gets a list of features")
            .WithDescription("Gets a list of features with pagination and filtering support")
            .Produces<PagedList<FeatureResponse>>()
            .RequirePermission("Permissions.Features.View")
            .MapToApiVersion(1);
    }
}
