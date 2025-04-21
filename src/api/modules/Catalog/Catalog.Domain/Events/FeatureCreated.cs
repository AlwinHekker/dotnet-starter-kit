using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record FeatureCreated : DomainEvent
{
    public Feature? Feature { get; set; }
}
