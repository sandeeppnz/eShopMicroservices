namespace Ordering.Domain.ValueObjects;

public record CustomerId
{
    public Guid Value { get; set; }
    private CustomerId(Guid value) => Value = value;

    public static CustomerId Of(Guid customerId) 
    {
        ArgumentNullException.ThrowIfNull(customerId, nameof(customerId));
        if(customerId == Guid.Empty)
        {
            throw new DomainException(nameof(customerId));
        }

        return new CustomerId(customerId);
    }
}
