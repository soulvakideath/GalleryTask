using Gallery.Core.Models;

namespace Gallery.Core.Interfaces.Services;

public interface IAlbumService
{
    Task CreateAlbum(Album album);
    Task DeleteAlbum(Guid id);
    Task<Album> GetAlbumById(Guid id);
    Task<List<Album>> GetAlbums();
    Task UpdateAlbum(Guid id, string title);
}