using Gallery.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gallery.Persistence.Configuration;

public partial class AlbumConfiguration : IEntityTypeConfiguration<AlbumEntity>
{
    public void Configure(EntityTypeBuilder<AlbumEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.Photos)
            .WithOne(l => l.Album)
            .HasForeignKey(l => l.AlbumId);
        
    }
}