using Gallery.Core.Models;

namespace Gallery.Core.Interfaces.Repositories;

public interface IAlbumRepository
{
    Task Create(Album album);
    Task Delete(Guid id);
    Task<List<Album>> Get();
    Task<Album> GetById(Guid id);
    Task Update(Guid id, string title);
}