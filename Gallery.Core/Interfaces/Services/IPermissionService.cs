using Gallery.Core.Enums;

namespace Gallery.Core.Interfaces.Services;

public interface IPermissionService
{
    Task<HashSet<Permission>> GetPermissionsAsync(Guid userId);
}