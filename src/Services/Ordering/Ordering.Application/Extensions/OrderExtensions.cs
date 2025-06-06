﻿namespace Ordering.Application.Extensions;

public static class OrderExtensions
{
    public static IEnumerable<OrderDto> ToOrderDtoList(this IEnumerable<Order> orders)
    {
        return orders.Select(order => new OrderDto(
                Id: order.Id.Value,
                CustomerId: order.CustomerId.Value,
                OrderName: order.OrderName.Value,
                ShippingAddress: new AddressDto(
                    FirstName: order.ShippingAddress.FirstName,
                    LastName: order.ShippingAddress.LastName,
                    EmailAddress: order.ShippingAddress.EmailAddress,
                    AddressLine: order.ShippingAddress.AddressLine,
                    Country: order.ShippingAddress.Country,
                    State: order.ShippingAddress.State,
                    Postcode: order.ShippingAddress.PostCode
                ),
                BillingAddress: new AddressDto(
                    FirstName: order.BillingAddress.FirstName,
                    LastName: order.BillingAddress.LastName,
                    EmailAddress: order.BillingAddress.EmailAddress,
                    AddressLine: order.BillingAddress.AddressLine,
                    Country: order.BillingAddress.Country,
                    State: order.BillingAddress.State,
                    Postcode: order.BillingAddress.PostCode
                ),
                Payment: new PaymentDto(
                    CardName: order.Payment.CardName,
                    CardNumber: order.Payment.CardNumber,
                    Expiration: order.Payment.Expiration,
                    CVV: order.Payment.CVV,
                    PaymentMethod: order.Payment.PaymentMethod
                ),
                Status: order.Status,
                OrderItems: order.OrderItems.Select(oi => new OrderItemDto(
                    OrderId: oi.Id.Value,
                    ProductId: oi.ProductId.Value,
                    Quantity: oi.Quantity,
                    Price: oi.Price
                )).ToList()
            ));
    }
    public static OrderDto ToOrderDto(this Order order)
    {
        return DtoFromOrder(order);
    }

    private static OrderDto DtoFromOrder(Order order)
    {
        return new OrderDto(
                    Id: order.Id.Value,
                    CustomerId: order.CustomerId.Value,
                    OrderName: order.OrderName.Value,
                    ShippingAddress: new AddressDto(order.ShippingAddress.FirstName, order.ShippingAddress.LastName, order.ShippingAddress.EmailAddress!, order.ShippingAddress.AddressLine, order.ShippingAddress.Country, order.ShippingAddress.State, order.ShippingAddress.PostCode),
                    BillingAddress: new AddressDto(order.BillingAddress.FirstName, order.BillingAddress.LastName, order.BillingAddress.EmailAddress!, order.BillingAddress.AddressLine, order.BillingAddress.Country, order.BillingAddress.State, order.BillingAddress.PostCode),
                    Payment: new PaymentDto(order.Payment.CardName!, order.Payment.CardNumber, order.Payment.Expiration, order.Payment.CVV, order.Payment.PaymentMethod),
                    Status: order.Status,
                    OrderItems: order.OrderItems.Select(oi => new OrderItemDto(oi.OrderId.Value, oi.ProductId.Value, oi.Quantity, oi.Price)).ToList()
                );
    }

}
