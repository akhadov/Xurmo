using Xurmo.Common.Application.Authorization;
using Xurmo.Common.Application.Messaging;

namespace Xurmo.Modules.Users.Application.Users.GetUserPermissions;
public sealed record GetUserPermissionsQuery(string IdentityId) : IQuery<PermissionsResponse>;
