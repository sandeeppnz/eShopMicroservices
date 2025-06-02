using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetOrderByName;

public class GetOrdersByNameQueryHandler(IApplicationDbContext dbContext) 
    : IQueryHandler<GetOrdersByNameQuery, GetOrderByNameResult>
{
    public async Task<GetOrderByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
    {
        var orders = await dbContext.Orders
            .Include(o=>o.OrderItems)
            .AsNoTracking()
            .Where(o => o.OrderName.Value.Contains(query.Name, StringComparison.OrdinalIgnoreCase))
            .OrderBy(o => o.OrderName)
            .ToListAsync(cancellationToken);

        return new GetOrderByNameResult(orders.ToOrderDtoList());
    }
}
