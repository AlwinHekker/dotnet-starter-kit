using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Product : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public bool IsConfigurable { get; private set; } = true;

    public bool IsActive { get; private set; } = true;
    public bool IsVisibleIndividually { get; private set; } = true;
    public bool IsInStock { get; private set; } = true;
    public bool IsFeatured { get; private set; } = true;

    public bool IsOnSale { get; private set; } = true;
    public bool IsNewArrival { get; private set; } = true;
    public DateTime? ValidFrom { get; private set; }
    public DateTime? ValidTo { get; private set; }
    public string? MetaTitle { get; private set; }
    public string? MetaDescription { get; private set; }
    public string? MetaKeywords { get; private set; }
    public string? ProductFamily { get; private set; }
    public Guid? BrandId { get; private set; }
    public virtual Brand Brand { get; private set; } = default!;
    public virtual ICollection<Feature> Features { get; private set; } = new List<Feature>();


    private Product() { }

    public Product(
        Guid id,
        string name,
        string? description,
        decimal price,
        Guid? brandId,
        bool isConfigurable = true,
        bool isActive = true,
        bool isVisibleIndividually = true,
        bool isInStock = true,
        bool isFeatured = true,
        bool isOnSale = true,
        bool isNewArrival = true,
        DateTime? validFrom = null,
        DateTime? validTo = null,
        string? metaTitle = null,
        string? metaDescription = null,
        string? metaKeywords = null,
        string? productFamily = null
    )
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        BrandId = brandId;
        IsConfigurable = isConfigurable;
        IsActive = isActive;
        IsVisibleIndividually = isVisibleIndividually;
        IsInStock = isInStock;
        IsFeatured = isFeatured;
        IsOnSale = isOnSale;
        IsNewArrival = isNewArrival;
        ValidFrom = validFrom;
        ValidTo = validTo;
        MetaTitle = metaTitle;
        MetaDescription = metaDescription;
        MetaKeywords = metaKeywords;
        ProductFamily = productFamily;

        QueueDomainEvent(new ProductCreated { Product = this });
    }

    public static Product Create(
        string name,
        string? description,
        decimal price,
        Guid? brandId,
        bool isConfigurable = true,
        bool isActive = true,
        bool isVisibleIndividually = true,
        bool isInStock = true,
        bool isFeatured = true,
        bool isOnSale = true,
        bool isNewArrival = true,
        DateTime? validFrom = null,
        DateTime? validTo = null,
        string? metaTitle = null,
        string? metaDescription = null,
        string? metaKeywords = null,
        string? productFamily = null
    )
    {
        return new Product(
            Guid.NewGuid(),
            name,
            description,
            price,
            brandId,
            isConfigurable,
            isActive,
            isVisibleIndividually,
            isInStock,
            isFeatured,
            isOnSale,
            isNewArrival,
            validFrom,
            validTo,
            metaTitle,
            metaDescription,
            metaKeywords,
            productFamily
        );
    }

    public Product Update(
        string? name = null,
        string? description = null,
        decimal? price = null,
        Guid? brandId = null,
        bool? isConfigurable = null,
        bool? isActive = null,
        bool? isVisibleIndividually = null,
        bool? isInStock = null,
        bool? isFeatured = null,
        bool? isOnSale = null,
        bool? isNewArrival = null,
        DateTime? validFrom = null,
        DateTime? validTo = null,
        string? metaTitle = null,
        string? metaDescription = null,
        string? metaKeywords = null,
        string? productFamily = null
    )
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(name) && !string.Equals(Name, name, StringComparison.OrdinalIgnoreCase))
        {
            Name = name;
            isUpdated = true;
        }

        if (!string.Equals(Description, description, StringComparison.OrdinalIgnoreCase))
        {
            Description = description;
            isUpdated = true;
        }

        if (price.HasValue && Price != price.Value)
        {
            Price = price.Value;
            isUpdated = true;
        }

        if (brandId.HasValue && brandId.Value != Guid.Empty && BrandId != brandId.Value)
        {
            BrandId = brandId.Value;
            isUpdated = true;
        }

        if (isConfigurable.HasValue && IsConfigurable != isConfigurable.Value)
        {
            IsConfigurable = isConfigurable.Value;
            isUpdated = true;
        }

        if (isActive.HasValue && IsActive != isActive.Value)
        {
            IsActive = isActive.Value;
            isUpdated = true;
        }

        if (isVisibleIndividually.HasValue && IsVisibleIndividually != isVisibleIndividually.Value)
        {
            IsVisibleIndividually = isVisibleIndividually.Value;
            isUpdated = true;
        }

        if (isInStock.HasValue && IsInStock != isInStock.Value)
        {
            IsInStock = isInStock.Value;
            isUpdated = true;
        }

        if (isFeatured.HasValue && IsFeatured != isFeatured.Value)
        {
            IsFeatured = isFeatured.Value;
            isUpdated = true;
        }

        if (isOnSale.HasValue && IsOnSale != isOnSale.Value)
        {
            IsOnSale = isOnSale.Value;
            isUpdated = true;
        }

        if (isNewArrival.HasValue && IsNewArrival != isNewArrival.Value)
        {
            IsNewArrival = isNewArrival.Value;
            isUpdated = true;
        }

        if (validFrom.HasValue && ValidFrom != validFrom.Value)
        {
            ValidFrom = validFrom.Value;
            isUpdated = true;
        }

        if (validTo.HasValue && ValidTo != validTo.Value)
        {
            ValidTo = validTo.Value;
            isUpdated = true;
        }

        if (!string.Equals(MetaTitle, metaTitle, StringComparison.OrdinalIgnoreCase))
        {
            MetaTitle = metaTitle;
            isUpdated = true;
        }

        if (!string.Equals(MetaDescription, metaDescription, StringComparison.OrdinalIgnoreCase))
        {
            MetaDescription = metaDescription;
            isUpdated = true;
        }

        if (!string.Equals(MetaKeywords, metaKeywords, StringComparison.OrdinalIgnoreCase))
        {
            MetaKeywords = metaKeywords;
            isUpdated = true;
        }

        if (!string.Equals(ProductFamily, productFamily, StringComparison.OrdinalIgnoreCase))
        {
            ProductFamily = productFamily;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new ProductUpdated { Product = this });
        }

        return this;
    }

    // --- Feature Management Methods ---

    /// <summary>
    /// Adds a new root feature to the product.
    /// </summary>
    public Feature AddRootFeature(string name, string? description)
    {
        var feature = Feature.Create(name, description, this.Id, parentFeatureId: null);
        Features.Add(feature);
        return feature;
    }

    /// <summary>
    /// Adds a new child feature under an existing feature in this product.
    /// </summary>
    public Feature AddChildFeature(string name, string? description, Feature parentFeature)
    {
        if (parentFeature == null || (!Features.Contains(parentFeature) && !IsDescendantFeature(parentFeature)))
            throw new ArgumentException("Parent feature must belong to this product.");

        var feature = Feature.Create(name, description, this.Id, parentFeatureId: parentFeature.Id);
        parentFeature.AddChildFeature(feature);
        return feature;
    }

    /// <summary>
    /// Helper: determines if a feature is a descendant in the product's feature tree.
    /// </summary>
    private bool IsDescendantFeature(Feature feature)
    {
        foreach (var root in Features)
        {
            if (IsDescendant(root, feature))
                return true;
        }
        return false;
    }

    private bool IsDescendant(Feature current, Feature target)
    {
        if (current == target)
            return true;
        foreach (var child in current.ChildFeatures)
        {
            if (IsDescendant(child, target))
                return true;
        }
        return false;
    }
}

