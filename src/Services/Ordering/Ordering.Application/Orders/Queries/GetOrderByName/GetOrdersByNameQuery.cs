﻿namespace Ordering.Application.Orders.Queries.GetOrderByName;

public record GetOrdersByNameQuery(string Name) 
    : IQuery<GetOrderByNameResult>
{
}
