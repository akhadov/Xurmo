using MediatR;
using Xurmo.Common.Application.Authorization;
using Xurmo.Common.Domain;
using Xurmo.Modules.Users.Application.Users.GetUserPermissions;

namespace Xurmo.Modules.Users.Infrastructure.Authorization;
internal sealed class PermissionService(ISender sender) : IPermissionService
{
    public async Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId)
    {
        return await sender.Send(new GetUserPermissionsQuery(identityId));
    }
}
