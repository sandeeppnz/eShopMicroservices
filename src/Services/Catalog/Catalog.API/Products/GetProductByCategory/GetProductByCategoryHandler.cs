namespace Catalog.API.Products.GetProducts;

public record GetProductByCategoryQuery(string Category): IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);

public class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
    : IRequestHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation($"GetProductsQueryHandler {query}", query);
        var products = await session.Query<Product>().Where(x=>x.Category.Contains(query.Category)).ToListAsync(cancellationToken);
        return new GetProductByCategoryResult(products);
    }
}
