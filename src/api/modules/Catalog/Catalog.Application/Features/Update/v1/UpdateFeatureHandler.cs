using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Features.Update.v1;
public sealed class UpdateFeatureHandler(
    ILogger<UpdateFeatureHandler> logger,
    [FromKeyedServices("catalog:features")] IRepository<Feature> repository)
    : IRequestHandler<UpdateFeatureCommand, UpdateFeatureResponse>
{
    public async Task<UpdateFeatureResponse> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var feature = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = feature ?? throw new FeatureNotFoundException(request.Id);
        var updatedFeature = feature.Update(request.Name, request.Description);
        await repository.UpdateAsync(updatedFeature, cancellationToken);
        logger.LogInformation("Feature with id : {FeatureId} updated.", feature.Id);
        return new UpdateFeatureResponse(feature.Id);
    }
}
