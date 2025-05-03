using MediatR;

namespace Common.BuildingBlocks.CQRS;

public interface IQueryHander<in TQuery>
    : IRequestHandler<TQuery, Unit>
    where TQuery : IQuery<Unit>
{
}

public interface IQueryHander<in TQuery, TResponse>
    : IRequestHandler<TQuery, TResponse> 
    where TQuery : IQuery<TResponse>
    where TResponse : notnull
{
}
