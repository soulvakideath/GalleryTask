using Gallery.Core.Interfaces.Repositories;
using Gallery.Core.Interfaces.Services;
using Gallery.Core.Models;

namespace Gallery.Application.Services;

public class AlbumService : IAlbumService
{
    private readonly IAlbumRepository _albumRepository;

    public AlbumService(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }
    
    public async Task CreateAlbum(Album album)
    {
        await _albumRepository.Create(album);
    }

    public async Task<List<Album>> GetAlbums()
    {
        return await _albumRepository.Get();
    }

    public async Task<Album> GetAlbumById(Guid id)
    {
        return await _albumRepository.GetById(id);
    }
    
    public async Task UpdateAlbum(Guid id, string title)
    {
        await _albumRepository.Update(id, title);
    }
    
    public async Task DeleteAlbum(Guid id)
    {
        await _albumRepository.Delete(id);
    }
}