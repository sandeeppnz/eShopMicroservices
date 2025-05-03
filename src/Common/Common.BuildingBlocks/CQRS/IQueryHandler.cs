using MediatR;

namespace Common.BuildingBlocks.CQRS;

public interface ICommandHander<in TCommand>
    : IRequestHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{
}

public interface ICommandHander<in TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse> 
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{
}
