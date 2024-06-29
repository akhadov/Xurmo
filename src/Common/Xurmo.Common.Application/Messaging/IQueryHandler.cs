using MediatR;
using Xurmo.Common.Domain;

namespace Xurmo.Common.Application.Messaging;
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
