﻿using MediatR;

namespace Common.BuildingBlocks.CQRS;

public interface IQuery<out TResponse>: IRequest<TResponse> where TResponse : notnull
{
}
