using Gallery.Core.Interfaces.Repositories;
using Gallery.Core.Interfaces.Services;
using Gallery.Core.Models;

namespace Gallery.Application.Services; 

public class PhotoService : IPhotoService
{
    public readonly IPhotoRepository _PhotoRepository;

    public PhotoService(IPhotoRepository photoRepository)
    {
        _PhotoRepository = photoRepository;
    }
    
    public async Task CreatePhoto(Photo photo)
    {
        await _PhotoRepository.Create(photo);
    }

     public async Task<List<Photo>> GetPhotos(Guid albumId)
     {
         return await _PhotoRepository.Get(albumId);
     }

    public async Task<Photo> GetPhotoByID(Guid id)
    {
        return await _PhotoRepository.GetById(id);
    }
    
    public async Task UpdatePhoto(Guid id, string url)
    {
        await _PhotoRepository.Update(id, url);
    }
    public async Task DeletePhoto(Guid id)
    {
        await _PhotoRepository.Delete(id);
    }
}