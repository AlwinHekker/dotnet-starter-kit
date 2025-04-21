using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Features.EventHandlers;

public class FeatureCreatedEventHandler(ILogger<FeatureCreatedEventHandler> logger) : INotificationHandler<FeatureCreated>
{
    public async Task Handle(FeatureCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling feature created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling feature created domain event..");
    }
}
