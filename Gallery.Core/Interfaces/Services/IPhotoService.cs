using Gallery.Core.Models;

namespace Gallery.Core.Interfaces.Services;

public interface IPhotoService
{
    Task CreatePhoto(Photo photo);
    Task DeletePhoto(Guid id);
    Task<Photo> GetPhotoByID(Guid id);
    Task<List<Photo>> GetPhotos(Guid albumId);
    Task UpdatePhoto(Guid id, string url);
}