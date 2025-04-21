using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Features.Delete.v1;
public sealed record DeleteFeatureCommand(
    Guid Id) : IRequest;
