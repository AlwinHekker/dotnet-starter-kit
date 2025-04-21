using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.Features.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.Features.Search.v1;
public sealed class SearchFeaturesHandler(
    [FromKeyedServices("catalog:features")] IReadRepository<Feature> repository)
    : IRequestHandler<SearchFeaturesCommand, PagedList<FeatureResponse>>
{
    public async Task<PagedList<FeatureResponse>> Handle(SearchFeaturesCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchFeatureSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<FeatureResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
