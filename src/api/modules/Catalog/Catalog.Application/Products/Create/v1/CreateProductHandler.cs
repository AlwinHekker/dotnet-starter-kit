using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Products.Create.v1;
public sealed class CreateProductHandler(
    ILogger<CreateProductHandler> logger,
    [FromKeyedServices("catalog:products")] IRepository<Product> repository)
    : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var product = Product.Create(
            name: request.Name,
            description: request.Description,
            price: request.Price,
            brandId: request.BrandId,
            isConfigurable: request.IsConfigurable,
            isActive: request.IsActive,
            isVisibleIndividually: request.IsVisibleIndividually,
            isInStock: request.IsInStock,
            isFeatured: request.IsFeatured,
            isOnSale: request.IsOnSale,
            isNewArrival: request.IsNewArrival,
            validFrom: request.ValidFrom,
            validTo: request.ValidTo,
            metaTitle: request.MetaTitle,
            metaDescription: request.MetaDescription,
            metaKeywords: request.MetaKeywords,
            productFamily: request.ProductFamily
        );

        await repository.AddAsync(product, cancellationToken);
        logger.LogInformation("product created {ProductId}", product.Id);
        return new CreateProductResponse(product.Id);
    }
}
