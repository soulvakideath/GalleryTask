using Gallery.Core.Models;
using Gallery.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gallery.Persistence.Configuration;

public class PhotoConfiguration : IEntityTypeConfiguration<PhotoEntity>
{
    public void Configure(EntityTypeBuilder<PhotoEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(l => l.Album)
            .WithMany(c => c.Photos);
    }
}