using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Features.Delete.v1;
public sealed class DeleteFeatureHandler(
    ILogger<DeleteFeatureHandler> logger,
    [FromKeyedServices("catalog:features")] IRepository<Feature> repository)
    : IRequestHandler<DeleteFeatureCommand>
{
    public async Task Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var feature = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = feature ?? throw new FeatureNotFoundException(request.Id);
        await repository.DeleteAsync(feature, cancellationToken);
        logger.LogInformation("Feature with id : {FeatureId} deleted", feature.Id);
    }
}
