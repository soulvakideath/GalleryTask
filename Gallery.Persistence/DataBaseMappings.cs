using AutoMapper;
using Gallery.Core.Models;
using Gallery.Persistence.Entities;

namespace Gallery.Persistence;

public class DataBaseMappings : Profile
{
    public DataBaseMappings()
    {
        CreateMap<AlbumEntity, Album>();
        CreateMap<PhotoEntity, Photo>();
        CreateMap<UserEntity, User>();
    }
}