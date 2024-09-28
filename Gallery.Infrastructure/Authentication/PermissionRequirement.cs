using Gallery.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Gallery.Infrastructure.Authentication;

public class PermissionRequirement(Permission[] permissions)
    : IAuthorizationRequirement
{
    public Permission[] Permissions { get; set; } = permissions;
}