using Xurmo.Common.Application.Messaging;

namespace Xurmo.Modules.Users.Application.Users.GetUser;
public sealed record GetUserQuery(Guid UserId) : IQuery<UserResponse>;
