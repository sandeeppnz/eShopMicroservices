
using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProducts;

public record GetProductByIdQuery(Guid Id): IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);

public class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
    : IRequestHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation($"GetProductsQueryHandler {query}", query);
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
        if (product is null) throw new ProductNotFoundException();
        return new GetProductByIdResult(product);
    }
}
