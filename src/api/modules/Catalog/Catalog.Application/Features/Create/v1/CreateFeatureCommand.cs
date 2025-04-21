using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Features.Create.v1;
public sealed record CreateFeatureCommand(
    [property: DefaultValue("Sample Feature")] string? Name,
    [property: DefaultValue("00000000-0000-0000-0000-000000000000")] Guid ProductId,
    [property: DefaultValue("Descriptive Description")] string? Description = null,
    Guid? ParentFeatureId = null
) : IRequest<CreateFeatureResponse>;
