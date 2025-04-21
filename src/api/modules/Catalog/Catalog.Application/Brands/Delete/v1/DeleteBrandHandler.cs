using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Brands.Delete.v1;
public sealed class DeleteFeatureHandler(
    ILogger<DeleteFeatureHandler> logger,
    [FromKeyedServices("catalog:brands")] IRepository<Brand> repository)
    : IRequestHandler<DeleteFeatureCommand>
{
    public async Task Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var brand = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = brand ?? throw new BrandNotFoundException(request.Id);
        await repository.DeleteAsync(brand, cancellationToken);
        logger.LogInformation("Brand with id : {BrandId} deleted", brand.Id);
    }
}
