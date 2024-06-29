using MediatR;
using Xurmo.Common.Domain;

namespace Xurmo.Common.Application.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
