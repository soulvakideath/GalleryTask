using AutoMapper;
using Gallery.Core.Enums;
using Gallery.Core.Interfaces.Repositories;
using Gallery.Core.Models;
using Gallery.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Persistence.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly GalleryDbContext _context;
    private readonly IMapper _mapper;

    public UsersRepository(GalleryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Add(User user)
    {
        var roleEntity = await _context.Roles
                             .SingleOrDefaultAsync(r => r.Id == (int)Role.Admin)
                         ?? throw new InvalidOperationException();

        var userEntity = new UserEntity()
        {
            Id = user.Id,
            UserName = user.UserName,
            PasswordHash = user.PasswordHash,
            Email = user.Email,
            Roles = [roleEntity]
        };

        await _context.Users.AddAsync(userEntity);
        await _context.SaveChangesAsync();
    }

    public Task Add(User user, Role role)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByEmail(string email)
    {
        var userEntity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

        return _mapper.Map<User>(userEntity);
    }

    public async Task<HashSet<Permission>> GetUserPermissions(Guid userId)
    {
        var roles = await _context.Users
            .AsNoTracking()
            .Include(u => u.Roles)
            .ThenInclude(r => r.Permissions)
            .Where(u => u.Id == userId)
            .Select(u => u.Roles)
            .ToArrayAsync();

        return roles
            .SelectMany(r => r)
            .SelectMany(r => r.Permissions)
            .Select(p => (Permission)p.Id)
            .ToHashSet();
    }
    
}