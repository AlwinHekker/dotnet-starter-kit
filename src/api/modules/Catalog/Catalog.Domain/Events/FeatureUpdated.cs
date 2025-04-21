using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record FeatureUpdated : DomainEvent
{
    public Feature? Feature { get; set; }
}
