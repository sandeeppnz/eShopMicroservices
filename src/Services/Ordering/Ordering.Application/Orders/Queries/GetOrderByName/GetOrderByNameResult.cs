﻿namespace Ordering.Application.Orders.Queries.GetOrderByName;

public record GetOrderByNameResult(IEnumerable<OrderDto> Orders);
