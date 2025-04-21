using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.Features.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Features.Search.v1;

public class SearchFeaturesCommand : PaginationFilter, IRequest<PagedList<FeatureResponse>>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}
