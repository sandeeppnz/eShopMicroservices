namespace Ordering.Domain.ValueObjects;

public record ProductId
{
    public Guid Value { get; set; }
    private ProductId(Guid value) => Value = value;

    public static ProductId Of(Guid productId)
    {
        ArgumentNullException.ThrowIfNull(productId, nameof(productId));
        if (productId == Guid.Empty)
        {
            throw new DomainException(nameof(productId));
        }

        return new ProductId(productId);
    }

}