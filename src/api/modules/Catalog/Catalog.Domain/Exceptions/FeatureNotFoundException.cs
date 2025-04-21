using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class FeatureNotFoundException : NotFoundException
{
    public FeatureNotFoundException(Guid id)
        : base($"Feature with id {id} not found")
    {
    }
}
