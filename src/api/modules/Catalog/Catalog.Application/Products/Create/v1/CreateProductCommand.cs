using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Products.Create.v1;
public sealed record CreateProductCommand(
    [property: DefaultValue("Sample Product")] string Name,
    [property: DefaultValue(10.0)] decimal Price,
    [property: DefaultValue("Descriptive Description")] string? Description = null,
    [property: DefaultValue(null)] Guid? BrandId = null,
    [property: DefaultValue(true)] bool IsConfigurable = true,
    [property: DefaultValue(true)] bool IsActive = true,
    [property: DefaultValue(true)] bool IsVisibleIndividually = true,
    [property: DefaultValue(true)] bool IsInStock = true,
    [property: DefaultValue(true)] bool IsFeatured = true,
    [property: DefaultValue(true)] bool IsOnSale = true,
    [property: DefaultValue(true)] bool IsNewArrival = true,
    [property: DefaultValue(null)] DateTime? ValidFrom = null,
    [property: DefaultValue(null)] DateTime? ValidTo = null,
    [property: DefaultValue(null)] string? MetaTitle = null,
    [property: DefaultValue(null)] string? MetaDescription = null,
    [property: DefaultValue(null)] string? MetaKeywords = null,
    [property: DefaultValue(null)] string? ProductFamily = null
) : IRequest<CreateProductResponse>;
