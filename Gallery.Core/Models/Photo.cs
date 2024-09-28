namespace Gallery.Core.Models;

public class Photo
{
    public Guid Id { get; private set; }
    
    public Guid AlbumId { get; }
    public string Url { get; private set; } = string.Empty;
    
    private Photo(Guid id, Guid albumId, string url)
    {
        Id = id;
        AlbumId = albumId;
        Url = url;
    }

    public static Photo Create(Guid id,Guid albumId, string url)
    {
        if (string.IsNullOrEmpty(url))
            throw new ArgumentException("Url cannot be null!");

        return new Photo(id, albumId, url);
    }
}