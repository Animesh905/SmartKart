using MediatR;

namespace SmartKart.Identity.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>
: IRequestHandler<TQuery, TResponse>
where TQuery : IQuery<TResponse>
{
}
