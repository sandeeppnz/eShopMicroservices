namespace Ordering.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Order.Id)
            .NotEmpty().WithMessage("Order Id is required.");

        RuleFor(x => x.Order.OrderName)
            .NotEmpty().WithMessage("Order Name is required.");

        RuleFor(x => x.Order.CustomerId)
            .NotEmpty().WithMessage("Customer Id is required.");
    }
}
