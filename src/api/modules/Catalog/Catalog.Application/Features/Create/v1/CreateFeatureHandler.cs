using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Features.Create.v1;
public sealed class CreateFeatureHandler(
    ILogger<CreateFeatureHandler> logger,
    [FromKeyedServices("catalog:features")] IRepository<Feature> repository)
    : IRequestHandler<CreateFeatureCommand, CreateFeatureResponse>
{
    public async Task<CreateFeatureResponse> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
       // Updated to match the latest Feature.Create signature
        var feature = Feature.Create(
            request.Name!,
            request.Description,
            request.ProductId,
            request.ParentFeatureId
        );
        await repository.AddAsync(feature, cancellationToken);
        logger.LogInformation("feature created {FeatureId}", feature.Id);
        return new CreateFeatureResponse(feature.Id);
    }
}
