using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Features.Get.v1;
public class GetFeatureRequest : IRequest<FeatureResponse>
{
    public Guid Id { get; set; }
    public GetFeatureRequest(Guid id) => Id = id;
}
