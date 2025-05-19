namespace Ordering.Domain.ValueObjects;

public record OrderItemId
{
    public Guid Value { get; set; }
    private OrderItemId(Guid value) => Value = value;

    public static OrderItemId Of(Guid orderItemId)
    {
        ArgumentNullException.ThrowIfNull(orderItemId, nameof(orderItemId));
        if (orderItemId == Guid.Empty)
        {
            throw new DomainException(nameof(orderItemId));
        }

        return new OrderItemId(orderItemId);
    }
}
