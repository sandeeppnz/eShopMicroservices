using MediatR;

namespace Common.BuildingBlocks.CQRS;

public interface ICommand: IRequest<Unit>
{

}

public interface ICommand<out TResponse>: IRequest<TResponse>
{

}
