namespace Ordering.Domain.ValueObjects;

public record OrderName
{
    public string Value { get; set; }
    private const int DefaultLength = 5;
    private OrderName(string value) => Value = value;

    public static OrderName Of(string orderName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(orderName, nameof(orderName));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(orderName.Length, DefaultLength, nameof(orderName));

        return new OrderName(orderName);
    }

}
