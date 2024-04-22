using GUL.Shared.FluentResults;
using MediatR;
namespace GUL.Abstraction.Message;

public interface IQuery<TResponse> : IRequest<IFluentResults<TResponse>>
{
}
