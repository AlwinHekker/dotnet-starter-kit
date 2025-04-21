using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Feature : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public Guid ProductId { get; private set; }
    public Guid? ParentFeatureId { get; private set; }
    public virtual Feature? ParentFeature { get; private set; }
    public virtual ICollection<Feature> ChildFeatures { get; private set; } = new List<Feature>();

    private Feature() { }

    private Feature(Guid id, string name, string? description, Guid productId, Guid? parentFeatureId = null)
    {
        Id = id;
        Name = name;
        Description = description;
        ProductId = productId;
        ParentFeatureId = parentFeatureId;
        // ChildFeatures initialized by default
        QueueDomainEvent(new FeatureCreated { Feature = this });
    }

    public static Feature Create(string name, string? description, Guid productId, Guid? parentFeatureId = null)
    {
        return new Feature(Guid.NewGuid(), name, description, productId, parentFeatureId);
    }

    public Feature Update(string? name, string? description)
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

        if (isUpdated)
        {
            QueueDomainEvent(new FeatureUpdated { Feature = this });
        }

        return this;
    }

    public void AddChildFeature(Feature childFeature)
    {
        if (childFeature == null) throw new ArgumentNullException(nameof(childFeature));
        if (childFeature.ParentFeatureId != this.Id)
            throw new InvalidOperationException("Child feature's ParentFeatureId must match this feature's Id.");

        ChildFeatures.Add(childFeature);
    }
}
