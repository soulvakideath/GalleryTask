using Gallery.Persistence.Configuration;
using Gallery.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Persistence;

public class GalleryDbContext(DbContextOptions<GalleryDbContext> options)
    : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<PhotoEntity> Photos { get; set; } 
    
    public DbSet<AlbumEntity> Albums { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GalleryDbContext).Assembly);
    }
}