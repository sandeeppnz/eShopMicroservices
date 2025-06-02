using Microsoft.Extensions.Logging;

namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderUpdatedEvent>
{
    private readonly ILogger<OrderCreatedEventHandler> logger = logger;

    public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event handled: {DomainEvent}",
            notification.GetType().Name
        );
        return Task.CompletedTask;
    }
}
