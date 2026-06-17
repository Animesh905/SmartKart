using MediatR;

namespace SmartKart.Identity.Application.Abstractions.Messaging;

public interface IQuery<TResponse>
: IRequest<TResponse>
{
}
