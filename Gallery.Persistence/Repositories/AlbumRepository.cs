using AutoMapper;
using Gallery.Core.Interfaces.Repositories;
using Gallery.Core.Models;
using Gallery.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Persistence.Repositories;

public class AlbumRepository : IAlbumRepository
{

    private readonly GalleryDbContext _context;
    private readonly IMapper _mapper;

    public AlbumRepository(GalleryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task Create(Album album)
    {
        var albumEntity = new AlbumEntity()
        {
            Id = album.Id,
            Title = album.Title
        };

        await _context.Albums.AddAsync(albumEntity);
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<Album>> Get()
    {
        var albumEntities = await _context.Albums
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<List<Album>>(albumEntities);
    }
    
    public async Task<Album> GetById(Guid id)
    {
        var albumEntity = await _context.Albums
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id) ?? throw new Exception();

        return _mapper.Map<Album>(albumEntity);
    }

    public async Task Update(Guid id, string title)
    {
        await _context.Albums
            .Where(a => a.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Title, title));
    }
    
    public async Task Delete(Guid id)
    {
        await _context.Albums
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }
}