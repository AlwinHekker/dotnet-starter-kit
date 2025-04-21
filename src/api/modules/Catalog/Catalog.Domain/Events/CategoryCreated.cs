using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record CategoryCreated : DomainEvent
{
    public Category? Category { get; set; }
}
