using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Features.Update.v1;
public sealed record UpdateFeatureCommand(
    Guid Id,
    string? Name,
    string? Description = null) : IRequest<UpdateFeatureResponse>;
