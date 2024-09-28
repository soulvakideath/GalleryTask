using AutoMapper;
using Gallery.Core.Interfaces.Repositories;
using Gallery.Core.Models;
using Gallery.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Persistence.Repositories;

public class PhotoRepository : IPhotoRepository
{
    private readonly GalleryDbContext _context;
    private readonly IMapper _mapper;

    public PhotoRepository(GalleryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task Create(Photo photo)
    {
        var photoEntity = new PhotoEntity()
        {
            Id = photo.Id,
            AlbumId = photo.AlbumId,
            Url = photo.Url
        };

        await _context.Photos.AddAsync(photoEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        await _context.Photos
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<List<Photo>> Get(Guid albumId)
    {
        var photoEntity = await _context.Photos
            .AsNoTracking()
            .Where(p => p.AlbumId == albumId)
            .ToListAsync();

        return _mapper.Map<List<Photo>>(photoEntity);
    }
    

    public async Task<Photo> GetById(Guid id)
    {
        var photoEntity = await _context.Photos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id) ?? throw new Exception();

        return _mapper.Map<Photo>(photoEntity);
    }

    public async Task Update(Guid id, string url)
    {
        await _context.Photos
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Url, url));
    }
}