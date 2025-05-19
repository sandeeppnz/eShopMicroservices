namespace Ordering.Domain.ValueObjects;

public record OrderId
{
    public Guid Value { get; set; }
    private OrderId(Guid value) => Value = value;

    public static OrderId Of(Guid orderId)
    {
        ArgumentNullException.ThrowIfNull(orderId, nameof(orderId));
        if (orderId == Guid.Empty)
        {
            throw new DomainException(nameof(orderId));
        }

        return new OrderId(orderId);
    }

}
