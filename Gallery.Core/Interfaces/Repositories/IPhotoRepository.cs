using Gallery.Core.Models;

namespace Gallery.Core.Interfaces.Repositories;

public interface IPhotoRepository
{
    Task Create(Photo photo);
    Task Delete(Guid id);
    Task<List<Photo>> Get(Guid albumId);
    Task<Photo> GetById(Guid id);
    Task Update(Guid id, string url);
}