using GUL.Shared.FluentResults;
using MediatR;

namespace GUL.Abstraction.Message;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, IFluentResults<TResponse>>
    where TQuery : IQuery<TResponse>
{
}