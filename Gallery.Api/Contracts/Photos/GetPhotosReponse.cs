namespace Gallery.Contracts.Photos;

public record GetPhotosReponse(
    Guid Id,
    Guid AlbumId,
    string url);