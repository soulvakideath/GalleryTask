namespace Gallery.Persistence.Entities;

public class PhotoEntity
{
    public Guid Id { get; set; }
    public Guid AlbumId { get; set; }
    public AlbumEntity? Album { get; set; }
    public string Url { get; set; } = string.Empty;
    
}