using Gallery.Core.Models;

namespace Gallery.Core.Interfaces.Repositories;

public interface IUsersRepository
{
    Task Add(User user);
    Task<User> GetByEmail(string email);
    Task<HashSet<Enums.Permission>> GetUserPermissions(Guid userId);
}