using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Features.Get.v1;
public sealed class GetFeatureHandler(
    [FromKeyedServices("catalog:features")] IReadRepository<Feature> repository,
    ICacheService cache)
    : IRequestHandler<GetFeatureRequest, FeatureResponse>
{
    public async Task<FeatureResponse> Handle(GetFeatureRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"feature:{request.Id}",
            async () =>
            {
                var featureItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (featureItem == null) throw new FeatureNotFoundException(request.Id);
                return new FeatureResponse(featureItem.Id, featureItem.Name, featureItem.Description);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
