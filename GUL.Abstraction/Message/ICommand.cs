using GUL.Shared.FluentResults;
using MediatR;

namespace GUL.Abstraction.Message;

public interface ICommand : IRequest<IFluentResults>
{
}

public interface ICommand<TResponse> : IRequest<IFluentResults<TResponse>>
{
}